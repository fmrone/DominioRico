using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName", "O primeiro nome é de preenchimento obrigatório");

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(firstName, 3, "Name.FirstName", "Nome deve conter no mínimo 3 caracteres")
                .HasMinLen(lastName, 3, "Name.LastName", "Sobrenome deve conter no mínimo 3 caracteres")
                .HasMaxLen(firstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caracteres")
                .HasMaxLen(lastName, 10, "Name.LastName", "Sobrenome deve conter no máximo 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
