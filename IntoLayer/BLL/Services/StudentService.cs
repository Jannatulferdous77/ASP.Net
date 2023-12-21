using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static bool Create(StudentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>(); // DTO => Raw
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Student>(obj); // <format>, (kake format korte hbe)

            return StudentRepo.Create(mapped);
        }

        public static List<StudentDTO> GetAll()
        {
            var data = StudentRepo.GetAll(); // get data from DAL
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>(); // Raw => DTO
            });
            var mapper = new Mapper(config);
            var mapped =  mapper.Map<List<StudentDTO>>(data);
            return mapped; // return it in Application layer(controller)
        }
    }
}
