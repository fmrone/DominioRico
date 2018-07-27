using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using System.Collections.Generic;
using PaymentContext.Domain.Queries;
using System.Linq;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name($"Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), Domain.Enums.EDocumentType.CPF),
                    new Email($"{i.ToString()}@vocenegocia.com.br")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentDoesNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}
