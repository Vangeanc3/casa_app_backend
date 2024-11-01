﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Contracts" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Contracts" PRIMARY KEY ("Id")
);

CREATE TABLE "ToDoCategories" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "BaseCategoryId" integer NULL,
    CONSTRAINT "PK_ToDoCategories" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ToDoCategories_ToDoCategories_BaseCategoryId" FOREIGN KEY ("BaseCategoryId") REFERENCES "ToDoCategories" ("Id")
);

CREATE TABLE "Invites" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "CreatedAt" timestamp with time zone NOT NULL,
    "Expiration" timestamp with time zone NOT NULL,
    "IsAccepted" boolean NULL,
    "WorkerType" integer NOT NULL,
    "Name" text NOT NULL,
    "ContractId" integer NOT NULL,
    "GuestEmail" text NOT NULL,
    "GuestPhone" text NULL,
    CONSTRAINT "PK_Invites" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Invites_Contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES "Contracts" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Users" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "Password" text NOT NULL,
    "Gender" integer NOT NULL,
    "Phone" text NOT NULL,
    "BirthDay" text NULL,
    "IsOwner" boolean NOT NULL,
    "ContractId" integer NULL,
    "Cpf" text NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Users_Contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES "Contracts" ("Id")
);

CREATE TABLE "ToDosDefault" (
    "Id" uuid NOT NULL,
    "Nome" text NOT NULL,
    "Descricao" text NOT NULL,
    "Status" integer NOT NULL,
    "Type" integer NOT NULL,
    "CategoryId" integer NOT NULL,
    "DayOfWeek" integer NOT NULL,
    "Recurring" integer NOT NULL,
    "CreatedById" integer NULL,
    "AssignedToId" integer NULL,
    "PetId" integer NULL,
    "VehicleId" integer NULL,
    "PlaceId" integer NULL,
    CONSTRAINT "PK_ToDosDefault" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ToDosDefault_ToDoCategories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "ToDoCategories" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Houses" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "OwnerId" integer NOT NULL,
    CONSTRAINT "PK_Houses" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Houses_Users_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Pets" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Type" integer NOT NULL,
    "HouseId" integer NOT NULL,
    "AssignTask" boolean NOT NULL,
    CONSTRAINT "PK_Pets" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Pets_Houses_HouseId" FOREIGN KEY ("HouseId") REFERENCES "Houses" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Places" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Type" integer NOT NULL,
    "AssignTask" boolean NOT NULL,
    "HouseId" integer NOT NULL,
    CONSTRAINT "PK_Places" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Places_Houses_HouseId" FOREIGN KEY ("HouseId") REFERENCES "Houses" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Vehicles" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Type" integer NOT NULL,
    "AssignTask" boolean NOT NULL,
    "HouseId" integer NOT NULL,
    CONSTRAINT "PK_Vehicles" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Vehicles_Houses_HouseId" FOREIGN KEY ("HouseId") REFERENCES "Houses" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Workers" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Type" integer NOT NULL,
    "Gender" integer NOT NULL,
    "HouseId" integer NOT NULL,
    CONSTRAINT "PK_Workers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Workers_Houses_HouseId" FOREIGN KEY ("HouseId") REFERENCES "Houses" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ToDos" (
    "Id" uuid NOT NULL,
    "Nome" text NOT NULL,
    "Descricao" text NOT NULL,
    "CreatedById" integer NOT NULL,
    "AssignedToId" integer NULL,
    "Status" integer NOT NULL,
    "EstimateDate" timestamp with time zone NOT NULL,
    "DoneDate" timestamp with time zone NOT NULL,
    "CanceledDate" timestamp with time zone NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "Type" integer NOT NULL,
    "CategoryId" integer NOT NULL,
    "Price" double precision NULL,
    "DayOfWeek" integer NOT NULL,
    "Recurring" integer NOT NULL,
    "PetId" integer NULL,
    "VehicleId" integer NULL,
    "PlaceId" integer NULL,
    CONSTRAINT "PK_ToDos" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ToDos_Pets_PetId" FOREIGN KEY ("PetId") REFERENCES "Pets" ("Id"),
    CONSTRAINT "FK_ToDos_Places_PlaceId" FOREIGN KEY ("PlaceId") REFERENCES "Places" ("Id"),
    CONSTRAINT "FK_ToDos_ToDoCategories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "ToDoCategories" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ToDos_Users_AssignedToId" FOREIGN KEY ("AssignedToId") REFERENCES "Users" ("Id"),
    CONSTRAINT "FK_ToDos_Users_CreatedById" FOREIGN KEY ("CreatedById") REFERENCES "Users" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ToDos_Vehicles_VehicleId" FOREIGN KEY ("VehicleId") REFERENCES "Vehicles" ("Id")
);

CREATE INDEX "IX_Houses_OwnerId" ON "Houses" ("OwnerId");

CREATE INDEX "IX_Invites_ContractId" ON "Invites" ("ContractId");

CREATE INDEX "IX_Pets_HouseId" ON "Pets" ("HouseId");

CREATE INDEX "IX_Places_HouseId" ON "Places" ("HouseId");

CREATE INDEX "IX_ToDoCategories_BaseCategoryId" ON "ToDoCategories" ("BaseCategoryId");

CREATE INDEX "IX_ToDos_AssignedToId" ON "ToDos" ("AssignedToId");

CREATE INDEX "IX_ToDos_CategoryId" ON "ToDos" ("CategoryId");

CREATE INDEX "IX_ToDos_CreatedById" ON "ToDos" ("CreatedById");

CREATE INDEX "IX_ToDos_PetId" ON "ToDos" ("PetId");

CREATE INDEX "IX_ToDos_PlaceId" ON "ToDos" ("PlaceId");

CREATE INDEX "IX_ToDos_VehicleId" ON "ToDos" ("VehicleId");

CREATE INDEX "IX_ToDosDefault_CategoryId" ON "ToDosDefault" ("CategoryId");

CREATE INDEX "IX_Users_ContractId" ON "Users" ("ContractId");

CREATE INDEX "IX_Vehicles_HouseId" ON "Vehicles" ("HouseId");

CREATE INDEX "IX_Workers_HouseId" ON "Workers" ("HouseId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230813220316_v1', '7.0.3');

COMMIT;

