using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace BLL.Services
{
    public class AttendenceService
    {
        public static List<EmployeeAttendenceDTO> Get()
        {
            var data = DataAccessFactory.AttendenceData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<EmployeeAttendence, EmployeeAttendenceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmployeeAttendenceDTO>>(data);
            return converted;
        }

        public static EmployeeAttendenceDTO Get(int id)
        {
            var data = DataAccessFactory.AttendenceData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeAttendence, EmployeeAttendenceDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<EmployeeAttendenceDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }

        public static EmployeeAttendenceDTO Create(EmployeeAttendenceDTO attendenceDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeAttendenceDTO, EmployeeAttendence>();
                cfg.CreateMap<EmployeeAttendence, EmployeeAttendenceDTO>();
            });
            var mapper = new Mapper(config);

            var attendence = mapper.Map<EmployeeAttendence>(attendenceDTO);

            var isSuccess = DataAccessFactory.AttendenceData().Create(attendence);

            if (isSuccess)
            {
                var createAttendence = DataAccessFactory.EmployeeData().Get(attendence.Id);

                var createAttendenceDTO = mapper.Map<EmployeeAttendenceDTO>(createAttendence);

                return createAttendenceDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
