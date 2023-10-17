using casa_app_backend.Domain.Models;
using casa_app_backend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Infra.Repository
{
    public class ContractRepository : BaseRepositoryEF<Contract>
    {
        public ContractRepository(AppDbContext db) : base(db)
        {
        }

        public override async Task Create(Contract entity)
        {
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == entity.OwnerId);

            if (user is null)
            {
                return NotFound("Não é possivel criar um contrato sem um usuário válido!!!");
            }

            Contract? existingContract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == user.ContractId);

            if (existingContract is not null)
            {
                return BadRequest("Já tem um contrato vinculado a esse usuário");
            }

            Invite? invite = await context.Invites.FirstOrDefaultAsync(i => i.GuestEmail == user.Email || i.GuestPhone == user.Phone);

            // CASO NÃO TENHA CONVITE
            if (invite is null)
            {
                Contract contract = mapper.Map<Contract>(entity);
                contract.Name = $"Contrato do(a) {user.Name}";
                await context.Contracts.AddAsync(contract);
                await context.SaveChangesAsync();

                user.IsOwner = true;
                user.ContractId = contract.Id;
                context.Users.Update(user);
                await context.SaveChangesAsync();

                CreateHouseDto houseDto = new() { Name = $"Casa do {user.Name}", OwnerId = user.Id };
                HouseConfig house = mapper.Map<HouseConfig>(houseDto);

                await context.Houses.AddAsync(house);
                await context.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "Contrato criado",
                        data = mapper.Map<ReadContractDto>(contract)
                    }
                    );
            }

            //SE TIVER CONVITE VERIFICAR SE A PROP IsAccepted É NULA
            if (invite.IsAccepted is null)
            {
                return Ok(new
                {
                    message = "Há um convite para você!!!",
                    data = mapper.Map<ReadInviteDto>(invite)
                });
            }

            // SE ELA NÃO FOR NULA, SIGNIFICA QUE O USUÁRIO RECUSOU OU ACEITOU O CONVITE
            if (invite.IsAccepted is true)
            {
                Contract? contract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == invite.ContractId);

                if (contract is null)
                {
                    return NotFound("O contrato que você foi convidado não existe!!!");
                }

                user.ContractId = contract.Id;
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return Ok("Usuário incluído no contrato");
            }
            else
            {
                Contract contract = mapper.Map<Contract>(entity);
                await context.Contracts.AddAsync(contract);
                await context.SaveChangesAsync();

                user.IsOwner = true;
                user.ContractId = contract.Id; // VERIFICAR SE EXISTE ID;
                context.Users.Update(user);
                await context.SaveChangesAsync();

                CreateHouseDto houseDto = new() { Name = $"Casa do {user.Name}", OwnerId = user.Id };
                HouseConfig house = mapper.Map<HouseConfig>(houseDto);

                await context.Houses.AddAsync(house);
                await context.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Contrato criado",
                       data = mapper.Map<ReadContractDto>(contract)
                   }
                   );
            }
        }  
    }
}