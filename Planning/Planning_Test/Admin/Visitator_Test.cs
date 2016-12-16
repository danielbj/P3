using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planning.ViewModel;
using Planning.Model;

namespace Planning.UnitTest.Admin
{
    [TestFixture]
    class Visitator_Test
    {
        //NewTask(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, int count)
        //AdmitCitizen(Citizen citizen) 
        //DischargeCitizen(Citizen citizen, DateTime dateDischarged)
        //ChangeTask(TaskDescription task, DateTime date)   
        //CreateCitizen(string cpr, string firstname, string lastname, string addressString)
        //ChangeCitizenAddress(Citizen citizen, string addressString, DateTime fromDate)
        //CreateAddress(string address, DateTime date)
        //ValidateAddress(string address)
        //ApproveSchedule(GroupSchedule groupSchedule, bool status)

        //GetAllAdmittedCitizens()
        //GetAllDischargedCitizens()

        //[UnitOfWork_StateUnderTest_ExpectedBehavior]


        #region TestAddresses

        Address SnedstedKolonihavevej16 = new Address("Kolonihavevej 16, 7752, Snedsted, Denmark");
        Address SnedstedVandhøjvej9 = new Address("Vandhøjvej 9, 7752, Snedsted, Denmark");
        Address SnedstedRosenvænget22 = new Address("Rosenvænget 22, 7752, Snedsted, Denmark");
        Address Snedstedkærvej9 = new Address("Kærvej 9, 7752, Snedsted, Denmark");
        Address SnedstedVandhøjvej19 = new Address("Vandhøjvej 19, 7752, Snedsted, Denmark");
        Address SnedstedGartnervænget7 = new Address("Gartnervænget 7, 7752, Snedsted, Denmark");
        Address SnedstedIdrætsvej13 = new Address("Idrætsvej 13, 7752, Snedsted, Denmark");
        #endregion

        #region TestCitizens
        private Citizen NewTestCitizen(int i)
        {
            List<Citizen> Citizens = new List<Citizen>();            
            Citizens.Add(new Citizen("1111111111", "Kathy", "Peterson", SnedstedKolonihavevej16, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Emily", "Simmons", SnedstedVandhøjvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Scott", "Hill", Snedstedkærvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Harry", "Morgan", SnedstedRosenvænget22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Anthony", "Smith", SnedstedVandhøjvej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "John", "Morris", SnedstedGartnervænget7, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Judith", "Miller", SnedstedIdrætsvej13, DateTime.Today));

            return Citizens[i];
        }

        #endregion

        #region TestSchedules
        private GroupSchedule NewTestTempSchedule(int i)
        {
            List<GroupSchedule> TempSchedules = new List<GroupSchedule>();
            TempSchedules.Add(new GroupSchedule(new DateTime(2016, 12, 21)));
            TempSchedules.Add(new GroupSchedule(new DateTime(2016, 12, 20)));
            TempSchedules.Add(new GroupSchedule(new DateTime(2016, 12, 22)));
            TempSchedules.Add(new GroupSchedule(new DateTime(2016, 12, 23)));
            TempSchedules.Add(new GroupSchedule(new DateTime(2016, 12, 24)));
            return TempSchedules[i];
        }

        private GroupSchedule NewTestDailySchedule(int i)
        {
            List<GroupSchedule> DailySchedules = new List<GroupSchedule>();
            DailySchedules.Add(new GroupSchedule("Monday"));
            DailySchedules.Add(new GroupSchedule("Wednesday"));
            DailySchedules.Add(new GroupSchedule("Thursday"));
            DailySchedules.Add(new GroupSchedule("Friday"));
            DailySchedules.Add(new GroupSchedule("Saturday"));
            DailySchedules.Add(new GroupSchedule("Sunday"));
            return DailySchedules[i];
        }

        #endregion

        #region CitizenContainers
        private List<Citizen> AdmittedTestCitizens()
        {
            List<Citizen> admittedCitizens = new List<Citizen>();            
            admittedCitizens.Add(NewTestCitizen(1));
            admittedCitizens.Add(NewTestCitizen(2));
            admittedCitizens.Add(NewTestCitizen(3));
            return admittedCitizens;
        }

        private List<Citizen> DischargedTestCitizens()
        {
            List<Citizen> dischargedCitizens = new List<Citizen>();
            dischargedCitizens.Add(NewTestCitizen(4));
            dischargedCitizens.Add(NewTestCitizen(5));
            dischargedCitizens.Add(NewTestCitizen(6));
            
            return dischargedCitizens;
        }

        #endregion

        private Visitator _visitator = new Visitator();





    #region AdmitCitizen        

        [TestCase(4, 5, 6)]
        public void AdmitCitien_CitizenIsDischarged_CitizenAdmitted(int citizen)
        {
            //arrange
            


            //act
            _visitator.AdmitCitizen(NewTestCitizen(citizen));

            //assert
            
        }

        [TestCase(1, 2, 3)]
        public void AdmitCitizen_CitizenAlreadyAdmitted_ContinueWithoutAdmitting(int citizen)
        {

        }

        [TestCase(0)]
        public void AdmitCitizen_CitizenNotFoundInTheSystem_SignalError(int citizen)
        {

        }
    #endregion

        #region DischargeCitizen
        public void DischargeCitizen_CitizenAlreadyDischarged_ContinueWithoutDischarging()
        {

        }

        public void DischargeCitizen_CitizenIsAdmitted_CitizenDischarged()
        {

        }

        public void DischargeCitizen_CitizenNotFound_SignalError()
        {

        }

        #endregion

        #region ChangeTask!MethodNotImplemented!
        //not implemented
        #endregion

        #region NewTask

        public void NewTask_ValidInput_TaskDescriptionAddedToCitizen()
        {

        }
        public void NewTask_ValidInput_TaskItemGenerated() 
        {

        }

        public void NewTask_CountIsLessThanOne_SignalInputError()
        {

        }
        public void NewTask_CitizenNotFound_SignalError()
        {

        }

        public void NewTask_DurationIsLessThanOne_SignalInputError()
        {

        }

        public void NewTask_DurationNegative_SignalInputError()
        {

        }

        #endregion

        #region CreateCitizen
        public void CreateCitizen_ValidInput_CitizenAddedToCitizenContainer()
        {

        }

        public void CreateCitizen_InvalidAddress_SignalInputError()
        {

        }

        public void CreateCitizen_InvalidCPRNumber_SignalInputError()
        {

        }

        public void CreateCitizen_CPRContainsHyphen_FormatCPRString()
        {

        }

        public void CreateCitizen_LastNameEmpty_SignalInputError()
        {

        }

        public void CreateCitizen_FirstNameEmpty_SignalInputError()
        {

        }



        #endregion

        #region ChangeCitizenAddress

        public void ChangeCitizenAddress_ValidInput_AddAddressToCitizen()
        {

        }
        public void ChangeCitizenAddress_CitizenNotFound_SignalError()
        {

        }

        public void ChangeCitizenAddress_InvalidAddress_SignalInputError()
        {

        }

        public void ChangeCitizenAddress_AddressEmpty_SignalInputError()
        {

        }




        #endregion

        #region ApproveSchedule

        public void ApproveSchedule_ApproveStatusTrue_SetApprovalStatusToTrue()
        {

        }

        public void ApproveSchedule_ApproveStatusFalse_SetApprovalStatusToFalse()
        {

        }

        public void ApproveSchedule_ScheduleNotFound_SignalError()
        {

        }

        public void ApproveSchedule_ScheduleAlreadyApproved_Continue()
        {

        }

        #endregion







    }
}
