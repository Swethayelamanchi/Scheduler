using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class Dal
    {
        private SqlConnection _connectioncon;

        public Dal()
        {
            _connectioncon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
        }


        #region Users

        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetUsers", _connectioncon);
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Users user = new Users();
                        user.UserName = reader.GetValue(0).ToString();
                        user.Password = reader.GetValue(1).ToString();
                        user.FirstName = reader.GetValue(2).ToString();
                        user.LastName = reader.GetValue(3).ToString();
                        user.Email = reader.GetValue(4).ToString();
                        user.Role = reader.GetValue(5).ToString();
                        users.Add(user);
                    }
                }
            }
            return users;
        }


        public int AddOrUpdateUser(bool isNew, string userName, string firstName, string lastName, string email, string role, string password)
        {
            int isExists = 0;
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_AddOrUpdateUser", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@isNew", Convert.ToInt32(isNew));
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@password", password);

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@isExists";
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    parameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();

                    isExists = Convert.ToInt32(command.Parameters["@isExists"].Value);

                    if (isExists == 1)
                        return -1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        public int ResetPassword(string userName, string password)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand(String.Format("Update [dbo].[Users] SET [Password]='{0}' Where [UserName] = '{1}'", password, userName), _connectioncon);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }
        }

        public int DeleteUser(string userName)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand(String.Format("Delete FROM [dbo].[Users] Where [UserName] = '{0}'", userName), _connectioncon);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        #endregion

        #region Holidays

        public List<Holiday> GetHolidays()
        {
            _connectioncon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
            List<Holiday> holidays = new List<Holiday>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetHolidays", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Holiday holiday = new Holiday();
                        holiday.HolidayId = Convert.ToInt32(reader.GetValue(0));
                        holiday.HolidayDate =Convert.ToDateTime(reader.GetValue(1)).ToString("yyyy/MM/dd");
                        holiday.WeekDay = Convert.ToDateTime(reader.GetValue(1)).ToString("dddd");
                        holiday.Description = reader.GetValue(2).ToString();
                        holidays.Add(holiday);
                    }
                }
            }
            return holidays;
        }



        public int AddOrUpdateHoliday(bool isNew, string holidayDate, string description)
        {
            int isExists = 0;
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_AddOrUpdateHoliday", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@isNew",Convert.ToInt32(isNew));
                    command.Parameters.AddWithValue("@holidayDate", Convert.ToDateTime(holidayDate));
                    command.Parameters.AddWithValue("@description", description);

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@isExists";
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    parameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();


                    isExists = Convert.ToInt32(command.Parameters["@isExists"].Value);

                    if (isExists == 1)
                        return -1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;
               
            }
          
        }



        public int DeleteHoliday(string holidayDate)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand(String.Format("Delete FROM [dbo].[Holidays] Where [Holiday] = '{0}'",holidayDate), _connectioncon);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        #endregion

        #region Instructors

        public List<Instructor> GetInstructors()
        {
            List<Instructor> instrictors = new List<Instructor>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetInstructors", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor();
                        instructor.InstructorId = Convert.ToInt32(reader.GetValue(0));
                        instructor.FirstName = reader.GetValue(1).ToString();
                        instructor.MiddleName = reader.GetValue(2).ToString();
                        instructor.LastName = reader.GetValue(3).ToString();
                        instructor.Email = reader.GetValue(4).ToString();
                        instrictors.Add(instructor);
                    }
                }
            }
            return instrictors;
        }



        public int AddOrUpdateInstructor(bool isNew, int instructorId, string firstName, string middleName, string lastName,string email)
        {
            int isExists = 0;
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_AddOrUpdateInstructor", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@isNew", Convert.ToInt32(isNew));
                    command.Parameters.AddWithValue("@InstructorId", instructorId);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@middleName", middleName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@email", email);

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@isExists";
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    parameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();


                    isExists = Convert.ToInt32(command.Parameters["@isExists"].Value);

                    if (isExists == 1)
                        return -1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }



        public int DeleteInstructor(int instructorId)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_DeleteInstructor", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorId", instructorId);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        #endregion

        #region Courses

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetCourses", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Course course = new Course();
                        course.CourseId = reader.GetValue(0).ToString();
                        course.Subject = reader.GetValue(1).ToString();
                        course.Category = reader.GetValue(2).ToString();
                        course.Title = reader.GetValue(3).ToString();
                        course.MinCredits = Convert.ToInt32(reader.GetValue(4));
                        course.MaxCredits = Convert.ToInt32(reader.GetValue(5));
                        course.SpecialApproval = Convert.ToBoolean(reader.GetValue(6));
                        courses.Add(course);
                    }
                }
            }
            return courses;
        }



        public int AddOrUpdateCourse(bool isNew, Course course)
        {
            int isExists = 0;
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_AddOrUpdateCourse", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@isNew", Convert.ToInt32(isNew));
                    command.Parameters.AddWithValue("@CourseId", course.CourseId);
                    command.Parameters.AddWithValue("@SubjectName", course.Subject);
                    command.Parameters.AddWithValue("@CategoryName", course.Category);
                    command.Parameters.AddWithValue("@Title", course.Title);
                    command.Parameters.AddWithValue("@MinCredits", course.MinCredits);
                    command.Parameters.AddWithValue("@MaxCredits", course.MaxCredits);
                    command.Parameters.AddWithValue("@SpecialApproval", course.SpecialApproval);

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@isExists";
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    parameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();


                    isExists = Convert.ToInt32(command.Parameters["@isExists"].Value);

                    if (isExists == 1)
                        return -1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }



        public int DeleteCourse(int courseId)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_DeleteCourse", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        #endregion

        //#region CourseMap

        //public List<CourseMap> GetCourseMap()
        //{
        //    List<CourseMap> courseMap = new List<CourseMap>();
        //    using (_connectioncon)
        //    {
        //        SqlCommand command = new SqlCommand("usp_GetCourseMap", _connectioncon);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        _connectioncon.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                CourseMap course = new CourseMap();
        //                course.CRN = Convert.ToInt32(reader.GetValue(0));
        //                course.Subject = reader.GetValue(1).ToString();
        //                course.Course = reader.GetValue(2).ToString();
        //                course.Section = Convert.ToInt32(reader.GetValue(3));
        //                course.MinCredits = Convert.ToInt32(reader.GetValue(4));
        //                course.MaxCredits = Convert.ToInt32(reader.GetValue(5));
        //                course.Title = reader.GetValue(6).ToString();
        //                course.Instructor = reader.GetValue(7).ToString();
        //                course.Category = reader.GetValue(8).ToString();
        //                course.SpecialApproval = Convert.ToBoolean(reader.GetValue(9));
        //                courseMap.Add(course);
        //            }
        //        }
        //    }
        //    return courseMap;
        //}

        //public int AddCourseMap(int CRN, string courseId,int instructorId,int section)
        //{
        //    int isExists = 0;
        //    using (_connectioncon)
        //    {
        //        try
        //        {
        //            SqlCommand command = new SqlCommand("usp_AddCourseMap", _connectioncon);
        //            command.CommandType = System.Data.CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@CRN", CRN);
        //            command.Parameters.AddWithValue("@CourseId", courseId);
        //            command.Parameters.AddWithValue("@InstructorId", instructorId);
        //            command.Parameters.AddWithValue("@Section", section);

        //            SqlParameter parameter = new SqlParameter();
        //            parameter.ParameterName = "@isExists";
        //            parameter.SqlDbType = System.Data.SqlDbType.Int;
        //            parameter.Direction = System.Data.ParameterDirection.Output;
        //            command.Parameters.Add(parameter);
        //            _connectioncon.Open();
        //            command.ExecuteNonQuery();

        //            isExists = Convert.ToInt32(command.Parameters["@isExists"].Value);

        //            if (isExists == 1)
        //                return -1;
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //        return 1;

        //    }

        //}

        //public int DeleteCRN(int CRN)
        //{
        //    using (_connectioncon)
        //    {
        //        try
        //        {
        //            SqlCommand command = new SqlCommand(String.Format("Delete FROM [dbo].[CourseMap] Where [CRN] = {0}", CRN), _connectioncon);
        //            _connectioncon.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //        return 1;

        //    }

        //}


        //#endregion

        #region General

        public List<Enums> GetEnums()
        {
            List<Enums> enums = new List<Enums>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetEnums", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Enums e = new Enums();
                        e.Type = reader.GetValue(0).ToString();
                        e.Value = reader.GetValue(1).ToString();
                        e.Description = reader.GetValue(2).ToString();

                        enums.Add(e);
                    }
                }
            }
            return enums;
        }

        #endregion


        #region Schedule

        public List<Schedule> GetSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetSchedules", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Schedule schedule = new Schedule();
                        schedule.ScheduleId = Convert.ToInt32(reader.GetValue(0));
                        schedule.CRN = Convert.ToInt32(reader.GetValue(1));
                        schedule.Subject = reader.GetValue(2).ToString();
                        schedule.Course = reader.GetValue(3).ToString();
                        schedule.Section = Convert.ToInt32(reader.GetValue(4));
                        schedule.Title = reader.GetValue(5).ToString();
                        schedule.Category = reader.GetValue(6).ToString(); ;
                        schedule.Instructor = reader.GetValue(7).ToString();
                        schedule.Days = reader.GetValue(8).ToString();
                        schedule.Time = reader.GetValue(9).ToString();
                        schedule.StartDate = Convert.ToDateTime(reader.GetValue(10)).ToString("yyyy/MM/dd");
                        schedule.Enddate = Convert.ToDateTime(reader.GetValue(11)).ToString("yyyy/MM/dd"); 
                        schedule.Building = reader.GetValue(12).ToString();
                        schedule.location = reader.GetValue(13).ToString();
                        schedules.Add(schedule);
                    }
                }
            }
            return schedules;
        }


        public int AddOrUpdateSchedule(bool isNew, Schedule schedule)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_AddOrUpdateSchedule", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@isNew", Convert.ToInt32(isNew));
                    command.Parameters.AddWithValue("@ScheduleId", schedule.ScheduleId);
                    command.Parameters.AddWithValue("@CRN", schedule.CRN);
                    command.Parameters.AddWithValue("@CourseId", schedule.Course);
                    command.Parameters.AddWithValue("@InstructorId", Convert.ToInt32(schedule.Instructor));
                    command.Parameters.AddWithValue("@Section", schedule.Section);
                    command.Parameters.AddWithValue("@RoomNumber", Convert.ToInt32(schedule.location));
                    command.Parameters.AddWithValue("@Days", schedule.Days);
                    command.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(schedule.StartDate));
                    command.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(schedule.Enddate));
                    command.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(schedule.StartTime));
                    command.Parameters.AddWithValue("@EndTime", Convert.ToDateTime(schedule.EndTime));
                    command.Parameters.AddWithValue("@Series", schedule.Series);

                    _connectioncon.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }


        public int DeleteSchedule(int scheduleId)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand(String.Format("Delete FROM [dbo].[Schedules] Where [ScheduleId] = {0}", scheduleId), _connectioncon);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        public List<ScheduleSearchOption> GetScheduleSearchOptions()
        {
            List<ScheduleSearchOption> scheduleOptions = new List<ScheduleSearchOption>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetScheduleSearchOptions", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduleSearchOption schedule = new ScheduleSearchOption();
                        schedule.InstructorId = Convert.ToInt32(reader.GetValue(0));
                        schedule.Instructor = reader.GetValue(1).ToString();
                        schedule.CourseId = reader.GetValue(2).ToString();
                        schedule.Title = reader.GetValue(3).ToString();
                        schedule.Section = reader.GetValue(4).ToString();

                        scheduleOptions.Add(schedule);
                    }
                }
            }
            return scheduleOptions;
        }



        #endregion


        #region Rooms

        public List<Rooms> GetRooms()
        {
            List<Rooms> rooms = new List<Rooms>();
            using (_connectioncon)
            {
                SqlCommand command = new SqlCommand("usp_GetRooms", _connectioncon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                _connectioncon.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Rooms room = new Rooms();
                        room.RoomNumber = Convert.ToInt32(reader.GetValue(0));
                        room.Location = reader.GetValue(1).ToString();
                        room.Capacity = Convert.ToInt32(reader.GetValue(2));
                        room.Building = reader.GetValue(3).ToString();
                        rooms.Add(room);
                    }
                }
            }
            return rooms;
        }



        public int AddOrUpdateRoom(bool isNew, Rooms room)
        {
            int isExists = 0;
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_AddOrUpdateRoom", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@isNew", Convert.ToInt32(isNew));
                    command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                    command.Parameters.AddWithValue("@Building", room.Building);
                    command.Parameters.AddWithValue("@location", room.Location);
                    command.Parameters.AddWithValue("@Capacity", room.Capacity);

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@isExists";
                    parameter.SqlDbType = System.Data.SqlDbType.Int;
                    parameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();


                    isExists = Convert.ToInt32(command.Parameters["@isExists"].Value);

                    if (isExists == 1)
                        return -1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }



        public int DeleteRoom(int roomNumber)
        {
            using (_connectioncon)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_DeleteRoom", _connectioncon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    _connectioncon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return 1;

            }

        }

        #endregion

    }
}
