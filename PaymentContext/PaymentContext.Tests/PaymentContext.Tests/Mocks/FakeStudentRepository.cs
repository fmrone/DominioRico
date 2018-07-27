using PaymentContext.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
                return true;
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "hello@vocenegocia.com.br")
                return true;
            return false;
        }
    }
}
