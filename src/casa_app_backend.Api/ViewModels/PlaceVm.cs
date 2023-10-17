using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Api.ViewModels
{
    public class PlaceVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }
        public bool AssignTask { get; set; } = true;
        public int HouseId { get; set; }
        public virtual HouseConfigVm House { get; set; } = null!;
        public virtual List<ToDoVm>? ToDos { get; set; }
    }
    public class PlaceNewVm
    {
       public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }        
        public int HouseId { get; set; }
    }
    public class PlaceUpdateVm
    {
      public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }   
    }
}