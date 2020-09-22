using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModels
{
    public class EditorProductViewModel: Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {
            if(CategoryId == 0)
                AddNotification("CategoryId", "Categoria invalida");

            AddNotifications(
                new Contract()
                .HasMaxLen(Title, 120, "Title","O titulo deve conter ate 120 caracteres.")
                .HasMinLen(Title, 3, "Title", "O titulo deve conter pelo menos 3 caracteres.")
                .IsGreaterThan(Price, 0, "Price", "O preco deve ser maior que zero.")
            );
        }
    }
}
