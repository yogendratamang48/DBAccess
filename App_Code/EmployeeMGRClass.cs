using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee3.App_Code
{
    
    public class tblOfficeItem
    {
        public int fldOfficeItemsID { get; set; }
        public int fldEmployeeID { get; set; }
        public string fldOfficeItemsDesc { get; set; }
        public int fldTotalValue { get; set; }
        public DateTime fldTakenDate { get; set; }
        public string fldNote { get; set; }

    }
    public class tblDesignation
    {
        public int fldDesignationID { get; set; }
        public int fldEmployeeID { get; set; }
        public int fldPostID { get; set; }
        public int fldLevelID { get; set; }
        public DateTime fldStartDate { get; set; }
        public int fldDepartmentID { get; set; }
        public string fldNote { get; set; }
    }
    public class tblEducation
    {

        public int fldEducationInfoID { get; set; }
        public int fldEmployeeID { get; set; }
        public string fldLevel { get; set; }
        public string fldBoardOrUniversity { get; set; }
        public string fldPassedYear { get; set; }
        public string fldPassedGrade { get; set; }
        public string fldMajorSubjects { get; set; }
        public string fldNote { get; set; }
    }
    public class tblEmployee
    {
        public int fldEmployeeID { get; set; }
        public string fldFirstName { get; set; }
        public string fldMiddleName { get; set; }
        public string fldLastName { get; set; }
        public string fldGender { get; set; }
        public int fldDobYear { get; set; }
        public int fldDobMonth { get; set; }
        public int fldDobDay { get; set; }
        public DateTime fldDob { get; set; }
        public string fldPhoneNo { get; set; }
        public string fldMobileNo { get; set; }
        public string fldFaxNo { get; set; }
        public string fldPersonalEmail { get; set; }
        public string fldOfficialEmail { get; set; }
        public string fldAddress { get; set; }
        public string fldDistrict { get; set; }
        public string fldCitizenshipNo { get; set; }
        public DateTime fldCitizenshipIssuedDate { get; set; }
        public string fldCitzenshipIssuedDistrict { get; set; }
        public DateTime fldDateofJoin { get; set; }
        public DateTime fldDateofPermanent { get; set; }
        public DateTime fldDateofRetirement { get; set; }
        public string fldMaritalStatus { get; set; }
        public int fldChildBoy { get; set; }
        public int fldChildGirl { get; set; }
        
        public float fldLeaveHome { get; set; }
        public float fldLeaveSick { get; set; }
        public Boolean fldIsActive { get; set; }
        public string fldCreatedBy { get; set; }
        public DateTime fldCreatedDate { get; set; }
        public string fldUpdatedBy { get; set; }
        public DateTime fldUpdatedDate { get; set; }
        
        public string fldNote { get; set; }
    }
    public class tblDocument
    {
        public int fldEmployeeID { get; set; }
        public int fldDocumentID { get; set; }

        public string fldPpPhoto { get; set; }
        public string fldCitizenshipCopy { get; set; }
        public string fldDocument { get; set; }
        
        
        //public string fldDocumentName { get; set; }
        //public string fldDocumentType { get; set; }
        public string fldNote { get; set; }
    }
    public class tblFamily
    {
        public int fldFamilyID { get; set; }
        public int fldEmployeeID { get; set; }
        public string fldMemberName { get; set; }
        public string fldGender { get; set; }
        public string fldRelation { get; set; }
        public int fldCurrentAge { get; set; }
        public string fldCurrentEducation { get; set; }
        public string fldContactNo { get; set; }
        public DateTime fldUpdatedDate { get; set; }
        public string fldNote { get; set; }
    }
    public class tblLeave
    {
        public int fldLeaveID { get; set; }
        public string fldLeaveDesc { get; set; }
        public int fldTotalLeaveDaysPerYear { get; set; }
        public string fldNote { get; set; }

    }
    public class tblLeaveDetails
    {
        public int fldLeaveDetailsID { get; set; }
        public int fldEmployerID { get; set; }
        public int fldLeaveID { get; set; }
        public float fldDaysTaken { get; set; }
        public DateTime fldTakenDate { get; set; }
        public string fldNote { get; set; }
    }

    public class tblLevel
    {
        public int fldLevelID { get; set; }
        public string fldDescription { get; set; }
        public string fldNote { get; set; }

    }


    public class tblPost
    {
        public int fldPostID { get; set; }
        public string fldPostDesc { get; set; }
        public string fldNote { get; set; }
    }

    public class tblTraining
    {
        public int fldTrainingID { get; set; }
        public int fldEmployeeId { get; set; }
        public string fldTitle { get; set; }
        public DateTime fldStartDate { get; set; }
        public DateTime fldEndDate { get; set; }
        public string fldTrainingGrade { get; set; }
        public string fldLocation { get; set; }
        public string fldOrganizer { get; set; }
        public string fldDocument { get; set; }
        public string fldNote { get; set; }

    }

    public class tblUser
    {
        public int fldUserId { get; set; }
        public int fldEmployeeId { get; set; }
        public string fldLoginName { get; set; }
        public string fldUsername { get; set; }
        public string fldPassword { get; set; }
        public string fldUserType { get; set; }
        public Boolean fldIsActive { get; set; }
        public string fldCreatedBy { get; set; }
        public DateTime fldCreatedDate { get; set; }
        public string fldUpdatedBy { get; set; }
        public DateTime fldUpdatedDate { get; set; }
        public string fldNote { get; set; }
    }
    public class tblRegister
    {
        public int fldRegisterID { get; set; }
        public int fldEmployeeID { get; set; }
        public string fldFirstName { get; set; }
        public string fldMiddleName { get; set; }
        public string fldLastName { get; set; }
        public string fldMobileNo { get; set; }
        public string fldPersonalEmail { get; set; }

    }
    public class tblDepartment
    {
        public int fldDepartmentID { get; set; }
        public string fldDepartmentName { get; set; }
        public int fldParentDepartmentID { get; set; }
        public string fldNote { get; set; }

    }
    public class tblNotice
    {
        public int fldNoticeID { get; set; }
        public string fldNoticeTitle { get; set; }
        public string fldNotice { get; set; }
        public DateTime fldCreatedDate { get; set; }
        public string fldNote { get; set; }
    }
    public class tblMessage
    {
        public int fldMessageID { get; set; }
        public string fldMessage { get; set; }
        public DateTime fldCreatedDate { get; set; }
        public string fldCreatedBy { get; set; }
    }
    public class tblWork
    {
        public int fldWorkScheduleID { get; set; }
        public int fldEmployeeID { get; set; }
        public string fldWorkDesc { get; set; }
        public DateTime fldAssignedDate { get; set; }
        public DateTime fldDeadLine { get; set; }
        public string fldlReportsTo { get; set; }
        public string fldNote { get; set; }
    }

    public class tblInsurance
    {
        public int fldInsuranceID { get; set; }
        public int fldEmployeeID { get; set; }
        public string fldInsuranceDesc { get; set; }
        public string fldInsuranceNote { get; set; }
    }
}