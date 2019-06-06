using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for all Reports (general variables present on all reports)
/// </summary>
public class Report
{
    public Report()
    {

    }

    // method for setting the appropriate insert query for the modified report - Create New Version - Awaiting Completion Status
    public static string InsertQuery()
    {
        string insertQuery = "";

        if (Name.Equals("MR Incident Report") && Version == "1") // MR Incident Report Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, NoOfPerson, FirstName1, LastName1, Contact1, PartyType1, Witness1, MemberNo1, CardHeld1, SignInSlip1, SignedInBy1, PDate1," +
                " PTimeH1, PTimeM1, PTimeTC1, Age1, AgeGroup1, Weight1, Height1, Hair1, ClothingTop1, ClothingBottom1, Shoes1, Weapon1, Gender1, DistFeatures1, InjuryDesc1, CauseInjury1, Comments1, FirstName2, LastName2, Contact2, PartyType2," +
                " Witness2, MemberNo2, CardHeld2, SignInSlip2, SignedInBy2, PDate2, PTimeH2, PTimeM2, PTimeTC2, Age2, AgeGroup2, Weight2, Height2, Hair2, ClothingTop2, ClothingBottom2, Shoes2, Weapon2, Gender2, DistFeatures2, InjuryDesc2," +
                " CauseInjury2, Comments2, FirstName3, LastName3, Contact3, PartyType3, Witness3, MemberNo3, CardHeld3, SignInSlip3, SignedInBy3, PDate3, PTimeH3, PTimeM3, PTimeTC3," +
                " Age3, AgeGroup3, Weight3, Height3, Hair3, ClothingTop3, ClothingBottom3, Shoes3, Weapon3, Gender3, DistFeatures3, InjuryDesc3, CauseInjury3, Comments3, FirstName4, LastName4, Contact4, PartyType4, Witness4, MemberNo4, CardHeld4," +
                " SignInSlip4, SignedInBy4, PDate4, PTimeH4, PTimeM4, PTimeTC4, Age4, AgeGroup4, Weight4, Height4, Hair4, ClothingTop4, ClothingBottom4, Shoes4, Weapon4, Gender4, DistFeatures4, InjuryDesc4, CauseInjury4, Comments4," +
                " FirstName5, LastName5, Contact5, PartyType5, Witness5, MemberNo5, CardHeld5, SignInSlip5, SignedInBy5, PDate5, PTimeH5, PTimeM5, PTimeTC5, Age5, AgeGroup5, Weight5, Height5, Hair5, ClothingTop5, ClothingBottom5, Shoes5, Weapon5," +
                " Gender5, DistFeatures5, InjuryDesc5, CauseInjury5, Comments5, Date, TimeH, TimeM, TimeTC, Location, LocationOther, IncidentHappened, ActionTaken, ActionTakenOther, Details, SecurityAttend," +
                " SecurityName, PoliceNotify, PoliceAction, PoliceStation, OfficersName, CamDesc1, CamRecorded1, CamFilePath1, CamSDate1, CamSTimeH1, CamSTimeM1," +
                " CamSTimeTC1, CamEDate1, CamETimeH1, CamETimeM1, CamETimeTC1, CamDesc2, CamRecorded2, CamFilePath2, CamSDate2, CamSTimeH2, CamSTimeM2, CamSTimeTC2," +
                " CamEDate2, CamETimeH2, CamETimeM2, CamETimeTC2, CamDesc3, CamRecorded3, CamFilePath3, CamSDate3, CamSTimeH3, CamSTimeM3, CamSTimeTC3, CamEDate3," +
                " CamETimeH3, CamETimeM3, CamETimeTC3, CamDesc4, CamRecorded4, CamFilePath4, CamSDate4, CamSTimeH4, CamSTimeM4, CamSTimeTC4, CamEDate4, CamETimeH4," +
                " CamETimeM4, CamETimeTC4, CamDesc5, CamRecorded5, CamFilePath5, CamSDate5, CamSTimeH5, CamSTimeM5, CamSTimeTC5, CamEDate5, CamETimeH5, CamETimeM5," +
                " CamETimeTC5, CamDesc6, CamRecorded6, CamFilePath6, CamSDate6, CamSTimeH6, CamSTimeM6, CamSTimeTC6, CamEDate6, CamETimeH6, CamETimeM6, CamETimeTC6," +
                " CamDesc7, CamRecorded7, CamFilePath7, CamSDate7, CamSTimeH7, CamSTimeM7, CamSTimeTC7, CamEDate7, CamETimeH7, CamETimeM7, CamETimeTC7, VisitorDOB1," +
                " VisitorAddress1, VisitorProofID1, StaffEmpNo1 , StaffAddress1, MemberDOB1, MemberAddress1, VisitorDOB2, VisitorAddress2, VisitorProofID2, StaffEmpNo2," +
                " StaffAddress2, MemberDOB2, MemberAddress2, VisitorDOB3, VisitorAddress3, VisitorProofID3, StaffEmpNo3 , StaffAddress3, MemberDOB3, MemberAddress3," +
                " VisitorDOB4, VisitorAddress4, VisitorProofID4, StaffEmpNo4, StaffAddress4, MemberDOB4, MemberAddress4, VisitorDOB5, VisitorAddress5, VisitorProofID5," +
                " StaffEmpNo5 , StaffAddress5, MemberDOB5, MemberAddress5, HappenedOther, HappenedSerious, HappenedRefuseEntry, HappenedAskedToLeave, Allegation, TxtPartyType1, TxtPTimeH1, TxtPTimeM1, TxtPTimeTC1, TxtGender1," +
                " TxtPartyType2, TxtPTimeH2, TxtPTimeM2, TxtPTimeTC2, TxtGender2, TxtPartyType3, TxtPTimeH3, TxtPTimeM3, TxtPTimeTC3, TxtGender3, TxtPartyType4, TxtPTimeH4," +
                " TxtPTimeM4, TxtPTimeTC4, TxtGender4, TxtPartyType5, TxtPTimeH5, TxtPTimeM5, TxtPTimeTC5, TxtGender5, TxtCamSTimeH1, TxtCamSTimeM1, TxtCamSTimeTC1," +
                " TxtCamETimeH1, TxtCamETimeM1, TxtCamETimeTC1, TxtCamSTimeH2, TxtCamSTimeM2, TxtCamSTimeTC2, TxtCamETimeH2, TxtCamETimeM2, TxtCamETimeTC2, TxtCamSTimeH3," +
                " TxtCamSTimeM3, TxtCamSTimeTC3, TxtCamETimeH3, TxtCamETimeM3, TxtCamETimeTC3, TxtCamSTimeH4, TxtCamSTimeM4, TxtCamSTimeTC4, TxtCamETimeH4, TxtCamETimeM4," +
                " TxtCamETimeTC4, TxtCamSTimeH5, TxtCamSTimeM5, TxtCamSTimeTC5, TxtCamETimeH5, TxtCamETimeM5, TxtCamETimeTC5, TxtCamSTimeH6, TxtCamSTimeM6, TxtCamSTimeTC6," +
                " TxtCamETimeH6, TxtCamETimeM6, TxtCamETimeTC6, TxtCamSTimeH7, TxtCamSTimeM7, TxtCamSTimeTC7, TxtCamETimeH7, TxtCamETimeM7, TxtCamETimeTC7, TxtTimeH," +
                " TxtTimeM, TxtTimeTC, PlayerId1, PlayerId2, PlayerId3, PlayerId4, PlayerId5, Alias1, Alias2, Alias3, Alias4, Alias5, MemberSince1, MemberSince2, MemberSince3, MemberSince4, MemberSince5, LastChanged) VALUES(" + Id + ", 1, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLIncident', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', " + ReportIncidentMr.NoOfPerson + ", '" + ReportIncidentMr.First1 + "', '" + ReportIncidentMr.Last1 + "', '" + ReportIncidentMr.Contact1 + "', '" + ReportIncidentMr.Type1 + "', '" + ReportIncidentMr.Witness1 + "'," +
                " '" + ReportIncidentMr.Member1 + "', '" + ReportIncidentMr.Card1 + "', '" + ReportIncidentMr.SignInSlip1 + "', '" + ReportIncidentMr.SignInBy1 + "', '" + ReportIncidentMr.PDate1 + "', " +
                " '" + ReportIncidentMr.PTimeH1 + "',  '" + ReportIncidentMr.PTimeM1 + "',  '" + ReportIncidentMr.PTimeTC1 + "', '" + ReportIncidentMr.Age1 + "', '" + ReportIncidentMr.AgeGroup1 + "', '" + ReportIncidentMr.Weight1 + "',  '" + ReportIncidentMr.Height1 + "', '" + ReportIncidentMr.Hair1 + "', '" + ReportIncidentMr.ClothingTop1 + "', '" + ReportIncidentMr.ClothingBottom1 + "', '" + ReportIncidentMr.Shoes1 + "', '" + ReportIncidentMr.Weapon1 + "', '" + ReportIncidentMr.Gender1 + "', '" + ReportIncidentMr.DistFeat1 + "'," +
                " '" + ReportIncidentMr.InjuryDesc1 + "',  '" + ReportIncidentMr.InjuryCause1 + "',  '" + ReportIncidentMr.InjuryComm1 + "',  '" + ReportIncidentMr.First2 + "',  '" + ReportIncidentMr.Last2 + "', '" + ReportIncidentMr.Contact2 + "', '" + ReportIncidentMr.Type2 + "',  '" + ReportIncidentMr.Witness2 + "'," +
                " '" + ReportIncidentMr.Member2 + "',  '" + ReportIncidentMr.Card2 + "',  '" + ReportIncidentMr.SignInSlip2 + "',  '" + ReportIncidentMr.SignInBy2 + "',  '" + ReportIncidentMr.PDate2 + "'," +
                " '" + ReportIncidentMr.PTimeH2 + "',  '" + ReportIncidentMr.PTimeM2 + "',  '" + ReportIncidentMr.PTimeTC2 + "',  '" + ReportIncidentMr.Age2 + "', '" + ReportIncidentMr.AgeGroup2 + "', '" + ReportIncidentMr.Weight2 + "',  '" + ReportIncidentMr.Height2 + "', '" + ReportIncidentMr.Hair2 + "', '" + ReportIncidentMr.ClothingTop2 + "', '" + ReportIncidentMr.ClothingBottom2 + "', '" + ReportIncidentMr.Shoes2 + "', '" + ReportIncidentMr.Weapon2 + "',  '" + ReportIncidentMr.Gender2 + "',  '" + ReportIncidentMr.DistFeat2 + "'," +
                " '" + ReportIncidentMr.InjuryDesc2 + "',  '" + ReportIncidentMr.InjuryCause2 + "',  '" + ReportIncidentMr.InjuryComm2 + "',  '" + ReportIncidentMr.First3 + "',  '" + ReportIncidentMr.Last3 + "', '" + ReportIncidentMr.Contact3 + "', '" + ReportIncidentMr.Type3 + "',  '" + ReportIncidentMr.Witness3 + "'," +
                " '" + ReportIncidentMr.Member3 + "',  '" + ReportIncidentMr.Card3 + "',  '" + ReportIncidentMr.SignInSlip3 + "',  '" + ReportIncidentMr.SignInBy3 + "',  '" + ReportIncidentMr.PDate3 + "'," +
                " '" + ReportIncidentMr.PTimeH3 + "',  '" + ReportIncidentMr.PTimeM3 + "',  '" + ReportIncidentMr.PTimeTC3 + "',  '" + ReportIncidentMr.Age3 + "', '" + ReportIncidentMr.AgeGroup3 + "', '" + ReportIncidentMr.Weight3 + "',  '" + ReportIncidentMr.Height3 + "', '" + ReportIncidentMr.Hair3 + "', '" + ReportIncidentMr.ClothingTop3 + "', '" + ReportIncidentMr.ClothingBottom3 + "', '" + ReportIncidentMr.Shoes3 + "', '" + ReportIncidentMr.Weapon3 + "',  '" + ReportIncidentMr.Gender3 + "',  '" + ReportIncidentMr.DistFeat3 + "'," +
                " '" + ReportIncidentMr.InjuryDesc3 + "',  '" + ReportIncidentMr.InjuryCause3 + "',  '" + ReportIncidentMr.InjuryComm3 + "',  '" + ReportIncidentMr.First4 + "',  '" + ReportIncidentMr.Last4 + "', '" + ReportIncidentMr.Contact4 + "', '" + ReportIncidentMr.Type4 + "',  '" + ReportIncidentMr.Witness4 + "'," +
                " '" + ReportIncidentMr.Member4 + "',  '" + ReportIncidentMr.Card4 + "',  '" + ReportIncidentMr.SignInSlip4 + "',  '" + ReportIncidentMr.SignInBy4 + "',  '" + ReportIncidentMr.PDate4 + "'," +
                " '" + ReportIncidentMr.PTimeH4 + "',  '" + ReportIncidentMr.PTimeM4 + "',  '" + ReportIncidentMr.PTimeTC4 + "',  '" + ReportIncidentMr.Age4 + "', '" + ReportIncidentMr.AgeGroup4 + "', '" + ReportIncidentMr.Weight4 + "',  '" + ReportIncidentMr.Height4 + "', '" + ReportIncidentMr.Hair4 + "', '" + ReportIncidentMr.ClothingTop4 + "', '" + ReportIncidentMr.ClothingBottom4 + "', '" + ReportIncidentMr.Shoes4 + "', '" + ReportIncidentMr.Weapon4 + "',  '" + ReportIncidentMr.Gender4 + "',  '" + ReportIncidentMr.DistFeat4 + "'," +
                " '" + ReportIncidentMr.InjuryDesc4 + "',  '" + ReportIncidentMr.InjuryCause4 + "',  '" + ReportIncidentMr.InjuryComm4 + "',  '" + ReportIncidentMr.First5 + "',  '" + ReportIncidentMr.Last5 + "', '" + ReportIncidentMr.Contact5 + "', '" + ReportIncidentMr.Type5 + "',  '" + ReportIncidentMr.Witness5 + "'," +
                " '" + ReportIncidentMr.Member5 + "',  '" + ReportIncidentMr.Card5 + "',  '" + ReportIncidentMr.SignInSlip5 + "',  '" + ReportIncidentMr.SignInBy5 + "',  '" + ReportIncidentMr.PDate5 + "'," +
                " '" + ReportIncidentMr.PTimeH5 + "',  '" + ReportIncidentMr.PTimeM5 + "',  '" + ReportIncidentMr.PTimeTC5 + "',  '" + ReportIncidentMr.Age5 + "', '" + ReportIncidentMr.AgeGroup5 + "', '" + ReportIncidentMr.Weight5 + "',  '" + ReportIncidentMr.Height5 + "', '" + ReportIncidentMr.Hair5 + "', '" + ReportIncidentMr.ClothingTop5 + "', '" + ReportIncidentMr.ClothingBottom5 + "', '" + ReportIncidentMr.Shoes5 + "', '" + ReportIncidentMr.Weapon5 + "',  '" + ReportIncidentMr.Gender5 + "',  '" + ReportIncidentMr.DistFeat5 + "'," +
                " '" + ReportIncidentMr.InjuryDesc5 + "',  '" + ReportIncidentMr.InjuryCause5 + "',  '" + ReportIncidentMr.InjuryComm5 + "',  '" + ReportIncidentMr.Date + "',  '" + ReportIncidentMr.Hour + "',  '" + ReportIncidentMr.Minute + "',  '" + ReportIncidentMr.TC + "'," +
                " '" + ReportIncidentMr.Location + "', '" + ReportIncidentMr.LocationOther + "',  '" + ReportIncidentMr.WhatHappened + "', '" + ReportIncidentMr.ActionTaken + "', '" + ReportIncidentMr.ActionTakenOther + "', '" + ReportIncidentMr.Details + "',  '" + ReportIncidentMr.SecurityAttend + "',  '" + ReportIncidentMr.SecurityName + "',  '" + ReportIncidentMr.PoliceNotified + "',  '" + ReportIncidentMr.PoliceAction + "'," +
                " '" + ReportIncidentMr.PoliceStation + "',  '" + ReportIncidentMr.OfficersName + "',  '" + ReportIncidentMr.CamDesc1 + "',  '" + ReportIncidentMr.CamRec1 + "',  '" + ReportIncidentMr.FilePath1 + "',  '" + ReportIncidentMr.SDate1 + "'," +
                " '" + ReportIncidentMr.STimeH1 + "',  '" + ReportIncidentMr.STimeM1 + "',  '" + ReportIncidentMr.STimeTC1 + "',  '" + ReportIncidentMr.EDate1 + "',  '" + ReportIncidentMr.ETimeH1 + "',  '" + ReportIncidentMr.ETimeM1 + "',  '" + ReportIncidentMr.ETimeTC1 + "',  '" + ReportIncidentMr.CamDesc2 + "',  '" + ReportIncidentMr.CamRec2 + "',  '" + ReportIncidentMr.FilePath2 + "',  '" + ReportIncidentMr.SDate2 + "'," +
                " '" + ReportIncidentMr.STimeH2 + "',  '" + ReportIncidentMr.STimeM2 + "',  '" + ReportIncidentMr.STimeTC2 + "',  '" + ReportIncidentMr.EDate2 + "',  '" + ReportIncidentMr.ETimeH2 + "',  '" + ReportIncidentMr.ETimeM2 + "',  '" + ReportIncidentMr.ETimeTC2 + "',  '" + ReportIncidentMr.CamDesc3 + "',  '" + ReportIncidentMr.CamRec3 + "',  '" + ReportIncidentMr.FilePath3 + "',  '" + ReportIncidentMr.SDate3 + "'," +
                " '" + ReportIncidentMr.STimeH3 + "',  '" + ReportIncidentMr.STimeM3 + "',  '" + ReportIncidentMr.STimeTC3 + "',  '" + ReportIncidentMr.EDate3 + "',  '" + ReportIncidentMr.ETimeH3 + "',  '" + ReportIncidentMr.ETimeM3 + "',  '" + ReportIncidentMr.ETimeTC3 + "',  '" + ReportIncidentMr.CamDesc4 + "',  '" + ReportIncidentMr.CamRec4 + "',  '" + ReportIncidentMr.FilePath4 + "',  '" + ReportIncidentMr.SDate4 + "'," +
                " '" + ReportIncidentMr.STimeH4 + "',  '" + ReportIncidentMr.STimeM4 + "',  '" + ReportIncidentMr.STimeTC4 + "',  '" + ReportIncidentMr.EDate4 + "',  '" + ReportIncidentMr.ETimeH4 + "',  '" + ReportIncidentMr.ETimeM4 + "',  '" + ReportIncidentMr.ETimeTC4 + "',  '" + ReportIncidentMr.CamDesc5 + "',  '" + ReportIncidentMr.CamRec5 + "',  '" + ReportIncidentMr.FilePath5 + "',  '" + ReportIncidentMr.SDate5 + "'," +
                " '" + ReportIncidentMr.STimeH5 + "',  '" + ReportIncidentMr.STimeM5 + "',  '" + ReportIncidentMr.STimeTC5 + "',  '" + ReportIncidentMr.EDate5 + "',  '" + ReportIncidentMr.ETimeH5 + "',  '" + ReportIncidentMr.ETimeM5 + "',  '" + ReportIncidentMr.ETimeTC5 + "',  '" + ReportIncidentMr.CamDesc6 + "',  '" + ReportIncidentMr.CamRec6 + "',  '" + ReportIncidentMr.FilePath6 + "',  '" + ReportIncidentMr.SDate6 + "'," +
                " '" + ReportIncidentMr.STimeH6 + "',  '" + ReportIncidentMr.STimeM6 + "',  '" + ReportIncidentMr.STimeTC6 + "',  '" + ReportIncidentMr.EDate6 + "',  '" + ReportIncidentMr.ETimeH6 + "',  '" + ReportIncidentMr.ETimeM6 + "',  '" + ReportIncidentMr.ETimeTC6 + "',  '" + ReportIncidentMr.CamDesc7 + "',  '" + ReportIncidentMr.CamRec7 + "',  '" + ReportIncidentMr.FilePath7 + "',  '" + ReportIncidentMr.SDate7 + "'," +
                " '" + ReportIncidentMr.STimeH7 + "',  '" + ReportIncidentMr.STimeM7 + "',  '" + ReportIncidentMr.STimeTC7 + "',  '" + ReportIncidentMr.EDate7 + "',  '" + ReportIncidentMr.ETimeH7 + "',  '" + ReportIncidentMr.ETimeM7 + "',  '" + ReportIncidentMr.ETimeTC7 + "',  '" + ReportIncidentMr.VDOB1 + "'," +
                " '" + ReportIncidentMr.VAddress1 + "', '" + ReportIncidentMr.VProofID1 + "', '" + ReportIncidentMr.StaffEmp1 + "', '" + ReportIncidentMr.StaffAddress1 + "', '" + ReportIncidentMr.MDOB1 + "', '" + ReportIncidentMr.MAddress1 + "', '" + ReportIncidentMr.VDOB2 + "', '" + ReportIncidentMr.VAddress2 + "'," +
                " '" + ReportIncidentMr.VProofID2 + "', '" + ReportIncidentMr.StaffEmp2 + "', '" + ReportIncidentMr.StaffAddress2 + "', '" + ReportIncidentMr.MDOB2 + "', '" + ReportIncidentMr.MAddress2 + "', '" + ReportIncidentMr.VDOB3 + "', '" + ReportIncidentMr.VAddress3 + "', '" + ReportIncidentMr.VProofID3 + "'," +
                " '" + ReportIncidentMr.StaffEmp3 + "', '" + ReportIncidentMr.StaffAddress3 + "', '" + ReportIncidentMr.MDOB3 + "', '" + ReportIncidentMr.MAddress3 + "', '" + ReportIncidentMr.VDOB4 + "', '" + ReportIncidentMr.VAddress4 + "', '" + ReportIncidentMr.VProofID4 + "', '" + ReportIncidentMr.StaffEmp4 + "'," +
                " '" + ReportIncidentMr.StaffAddress4 + "', '" + ReportIncidentMr.MDOB4 + "', '" + ReportIncidentMr.MAddress4 + "', '" + ReportIncidentMr.VDOB5 + "', '" + ReportIncidentMr.VAddress5 + "', '" + ReportIncidentMr.VProofID5 + "', '" + ReportIncidentMr.StaffEmp5 + "', '" + ReportIncidentMr.StaffAddress5 + "'," +
                " '" + ReportIncidentMr.MDOB5 + "', '" + ReportIncidentMr.MAddress5 + "', '" + ReportIncidentMr.HappenedOther + "', '" + ReportIncidentMr.HappenedSerious + "', '" + ReportIncidentMr.HappenedRefuseEntry + "', '" + ReportIncidentMr.HappenedAskedLeave + "', '" + ReportIncidentMr.Allegation + "', '" + ReportIncidentMr.TxtPartyType1 + "', '" + ReportIncidentMr.TxtPTimeH1 + "', '" + ReportIncidentMr.TxtPTimeM1 + "', '" + ReportIncidentMr.TxtPTimeTC1 + "'," +
                " '" + ReportIncidentMr.TxtGender1 + "', '" + ReportIncidentMr.TxtPartyType2 + "', '" + ReportIncidentMr.TxtPTimeH2 + "', '" + ReportIncidentMr.TxtPTimeM2 + "', '" + ReportIncidentMr.TxtPTimeTC2 + "', '" + ReportIncidentMr.TxtGender2 + "', '" + ReportIncidentMr.TxtPartyType3 + "', '" + ReportIncidentMr.TxtPTimeH3 + "'," +
                " '" + ReportIncidentMr.TxtPTimeM3 + "', '" + ReportIncidentMr.TxtPTimeTC3 + "', '" + ReportIncidentMr.TxtGender3 + "', '" + ReportIncidentMr.TxtPartyType4 + "', '" + ReportIncidentMr.TxtPTimeH4 + "', '" + ReportIncidentMr.TxtPTimeM4 + "', '" + ReportIncidentMr.TxtPTimeTC4 + "', '" + ReportIncidentMr.TxtGender4 + "'," +
                " '" + ReportIncidentMr.TxtPartyType5 + "', '" + ReportIncidentMr.TxtPTimeH5 + "', '" + ReportIncidentMr.TxtPTimeM5 + "', '" + ReportIncidentMr.TxtPTimeTC5 + "', '" + ReportIncidentMr.TxtGender5 + "', '" + ReportIncidentMr.TxtCamSTimeH1 + "', '" + ReportIncidentMr.TxtCamSTimeM1 + "', '" + ReportIncidentMr.TxtCamSTimeTC1 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH1 + "', '" + ReportIncidentMr.TxtCamETimeM1 + "', '" + ReportIncidentMr.TxtCamETimeTC1 + "', '" + ReportIncidentMr.TxtCamSTimeH2 + "', '" + ReportIncidentMr.TxtCamSTimeM2 + "', '" + ReportIncidentMr.TxtCamSTimeTC2 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH2 + "', '" + ReportIncidentMr.TxtCamETimeM2 + "', '" + ReportIncidentMr.TxtCamETimeTC2 + "', '" + ReportIncidentMr.TxtCamSTimeH3 + "', '" + ReportIncidentMr.TxtCamSTimeM3 + "', '" + ReportIncidentMr.TxtCamSTimeTC3 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH3 + "', '" + ReportIncidentMr.TxtCamETimeM3 + "', '" + ReportIncidentMr.TxtCamETimeTC3 + "', '" + ReportIncidentMr.TxtCamSTimeH4 + "', '" + ReportIncidentMr.TxtCamSTimeM4 + "', '" + ReportIncidentMr.TxtCamSTimeTC4 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH4 + "', '" + ReportIncidentMr.TxtCamETimeM4 + "', '" + ReportIncidentMr.TxtCamETimeTC4 + "', '" + ReportIncidentMr.TxtCamSTimeH5 + "', '" + ReportIncidentMr.TxtCamSTimeM5 + "', '" + ReportIncidentMr.TxtCamSTimeTC5 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH5 + "', '" + ReportIncidentMr.TxtCamETimeM5 + "', '" + ReportIncidentMr.TxtCamETimeTC5 + "', '" + ReportIncidentMr.TxtCamSTimeH6 + "', '" + ReportIncidentMr.TxtCamSTimeM6 + "', '" + ReportIncidentMr.TxtCamSTimeTC6 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH6 + "', '" + ReportIncidentMr.TxtCamETimeM6 + "', '" + ReportIncidentMr.TxtCamETimeTC6 + "', '" + ReportIncidentMr.TxtCamSTimeH7 + "', '" + ReportIncidentMr.TxtCamSTimeM7 + "', '" + ReportIncidentMr.TxtCamSTimeTC7 + "'," +
                " '" + ReportIncidentMr.TxtCamETimeH7 + "', '" + ReportIncidentMr.TxtCamETimeM7 + "', '" + ReportIncidentMr.TxtCamETimeTC7 + "', '" + ReportIncidentMr.TxtTimeH + "', '" + ReportIncidentMr.TxtTimeM + "', '" + ReportIncidentMr.TxtTimeTC + "', '" + ReportIncidentMr.PlayerId1 + "', '" + ReportIncidentMr.PlayerId2 + "', '" + ReportIncidentMr.PlayerId3 + "', '" + ReportIncidentMr.PlayerId4 + "', '" + ReportIncidentMr.PlayerId5 + "', '" + ReportIncidentMr.Alias1 + "', '" + ReportIncidentMr.Alias2 + "', '" + ReportIncidentMr.Alias3 + "', '" + ReportIncidentMr.Alias4 + "', '" + ReportIncidentMr.Alias5 + "'," +
                " '" + ReportIncidentMr.MemberSince1 + "', '" + ReportIncidentMr.MemberSince2 + "', '" + ReportIncidentMr.MemberSince3 + "', '" + ReportIncidentMr.MemberSince4 + "', '" + ReportIncidentMr.MemberSince5 + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("CU Incident Report") && Version == "1") // CU Incident Report Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, NoOfPerson, FirstName1, LastName1, Contact1, PartyType1, Witness1, MemberNo1, CardHeld1, SignInSlip1, SignedInBy1, PDate1," +
                " PTimeH1, PTimeM1, PTimeTC1, Age1, AgeGroup1, Weight1, Height1, Hair1, ClothingTop1, ClothingBottom1, Shoes1, Weapon1, Gender1, DistFeatures1, InjuryDesc1, CauseInjury1, Comments1, FirstName2, LastName2, Contact2, PartyType2," +
                " Witness2, MemberNo2, CardHeld2, SignInSlip2, SignedInBy2, PDate2, PTimeH2, PTimeM2, PTimeTC2, Age2, AgeGroup2, Weight2, Height2, Hair2, ClothingTop2, ClothingBottom2, Shoes2, Weapon2, Gender2, DistFeatures2, InjuryDesc2," +
                " CauseInjury2, Comments2, FirstName3, LastName3, Contact3, PartyType3, Witness3, MemberNo3, CardHeld3, SignInSlip3, SignedInBy3, PDate3, PTimeH3, PTimeM3, PTimeTC3," +
                " Age3, AgeGroup3, Weight3, Height3, Hair3, ClothingTop3, ClothingBottom3, Shoes3, Weapon3, Gender3, DistFeatures3, InjuryDesc3, CauseInjury3, Comments3, FirstName4, LastName4, Contact4, PartyType4, Witness4, MemberNo4, CardHeld4," +
                " SignInSlip4, SignedInBy4, PDate4, PTimeH4, PTimeM4, PTimeTC4, Age4, AgeGroup4, Weight4, Height4, Hair4, ClothingTop4, ClothingBottom4, Shoes4, Weapon4, Gender4, DistFeatures4, InjuryDesc4, CauseInjury4, Comments4," +
                " FirstName5, LastName5, Contact5, PartyType5, Witness5, MemberNo5, CardHeld5, SignInSlip5, SignedInBy5, PDate5, PTimeH5, PTimeM5, PTimeTC5, Age5, AgeGroup5, Weight5, Height5, Hair5, ClothingTop5, ClothingBottom5, Shoes5, Weapon5," +
                " Gender5, DistFeatures5, InjuryDesc5, CauseInjury5, Comments5, Date, TimeH, TimeM, TimeTC, Location, LocationOther, IncidentHappened, ActionTaken, ActionTakenOther, Details, SecurityAttend," +
                " SecurityName, PoliceNotify, PoliceAction, PoliceStation, OfficersName, CamDesc1, CamRecorded1, CamFilePath1, CamSDate1, CamSTimeH1, CamSTimeM1," +
                " CamSTimeTC1, CamEDate1, CamETimeH1, CamETimeM1, CamETimeTC1, CamDesc2, CamRecorded2, CamFilePath2, CamSDate2, CamSTimeH2, CamSTimeM2, CamSTimeTC2," +
                " CamEDate2, CamETimeH2, CamETimeM2, CamETimeTC2, CamDesc3, CamRecorded3, CamFilePath3, CamSDate3, CamSTimeH3, CamSTimeM3, CamSTimeTC3, CamEDate3," +
                " CamETimeH3, CamETimeM3, CamETimeTC3, CamDesc4, CamRecorded4, CamFilePath4, CamSDate4, CamSTimeH4, CamSTimeM4, CamSTimeTC4, CamEDate4, CamETimeH4," +
                " CamETimeM4, CamETimeTC4, CamDesc5, CamRecorded5, CamFilePath5, CamSDate5, CamSTimeH5, CamSTimeM5, CamSTimeTC5, CamEDate5, CamETimeH5, CamETimeM5," +
                " CamETimeTC5, CamDesc6, CamRecorded6, CamFilePath6, CamSDate6, CamSTimeH6, CamSTimeM6, CamSTimeTC6, CamEDate6, CamETimeH6, CamETimeM6, CamETimeTC6," +
                " CamDesc7, CamRecorded7, CamFilePath7, CamSDate7, CamSTimeH7, CamSTimeM7, CamSTimeTC7, CamEDate7, CamETimeH7, CamETimeM7, CamETimeTC7, VisitorDOB1," +
                " VisitorAddress1, VisitorProofID1, StaffEmpNo1 , StaffAddress1, MemberDOB1, MemberAddress1, VisitorDOB2, VisitorAddress2, VisitorProofID2, StaffEmpNo2," +
                " StaffAddress2, MemberDOB2, MemberAddress2, VisitorDOB3, VisitorAddress3, VisitorProofID3, StaffEmpNo3 , StaffAddress3, MemberDOB3, MemberAddress3," +
                " VisitorDOB4, VisitorAddress4, VisitorProofID4, StaffEmpNo4, StaffAddress4, MemberDOB4, MemberAddress4, VisitorDOB5, VisitorAddress5, VisitorProofID5," +
                " StaffEmpNo5 , StaffAddress5, MemberDOB5, MemberAddress5, HappenedOther, HappenedSerious, HappenedRefuseEntry, HappenedAskedToLeave, Allegation, TxtPartyType1, TxtPTimeH1, TxtPTimeM1, TxtPTimeTC1, TxtGender1," +
                " TxtPartyType2, TxtPTimeH2, TxtPTimeM2, TxtPTimeTC2, TxtGender2, TxtPartyType3, TxtPTimeH3, TxtPTimeM3, TxtPTimeTC3, TxtGender3, TxtPartyType4, TxtPTimeH4," +
                " TxtPTimeM4, TxtPTimeTC4, TxtGender4, TxtPartyType5, TxtPTimeH5, TxtPTimeM5, TxtPTimeTC5, TxtGender5, TxtCamSTimeH1, TxtCamSTimeM1, TxtCamSTimeTC1," +
                " TxtCamETimeH1, TxtCamETimeM1, TxtCamETimeTC1, TxtCamSTimeH2, TxtCamSTimeM2, TxtCamSTimeTC2, TxtCamETimeH2, TxtCamETimeM2, TxtCamETimeTC2, TxtCamSTimeH3," +
                " TxtCamSTimeM3, TxtCamSTimeTC3, TxtCamETimeH3, TxtCamETimeM3, TxtCamETimeTC3, TxtCamSTimeH4, TxtCamSTimeM4, TxtCamSTimeTC4, TxtCamETimeH4, TxtCamETimeM4," +
                " TxtCamETimeTC4, TxtCamSTimeH5, TxtCamSTimeM5, TxtCamSTimeTC5, TxtCamETimeH5, TxtCamETimeM5, TxtCamETimeTC5, TxtCamSTimeH6, TxtCamSTimeM6, TxtCamSTimeTC6," +
                " TxtCamETimeH6, TxtCamETimeM6, TxtCamETimeTC6, TxtCamSTimeH7, TxtCamSTimeM7, TxtCamSTimeTC7, TxtCamETimeH7, TxtCamETimeM7, TxtCamETimeTC7, TxtTimeH," +
                " TxtTimeM, TxtTimeTC, PlayerId1, PlayerId2, PlayerId3, PlayerId4, PlayerId5, Alias1, Alias2, Alias3, Alias4, Alias5, MemberSince1, MemberSince2, MemberSince3, MemberSince4, MemberSince5, LastChanged) VALUES(" + Id + ", 9, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_ClubUminaIncident', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', " + ReportIncidentCu.NoOfPerson + ", '" + ReportIncidentCu.First1 + "', '" + ReportIncidentCu.Last1 + "', '" + ReportIncidentCu.Contact1 + "', '" + ReportIncidentCu.Type1 + "', '" + ReportIncidentCu.Witness1 + "'," +
                " '" + ReportIncidentCu.Member1 + "', '" + ReportIncidentCu.Card1 + "', '" + ReportIncidentCu.SignInSlip1 + "', '" + ReportIncidentCu.SignInBy1 + "', '" + ReportIncidentCu.PDate1 + "', " +
                " '" + ReportIncidentCu.PTimeH1 + "',  '" + ReportIncidentCu.PTimeM1 + "',  '" + ReportIncidentCu.PTimeTC1 + "', '" + ReportIncidentCu.Age1 + "', '" + ReportIncidentCu.AgeGroup1 + "', '" + ReportIncidentCu.Weight1 + "',  '" + ReportIncidentCu.Height1 + "', '" + ReportIncidentCu.Hair1 + "', '" + ReportIncidentCu.ClothingTop1 + "', '" + ReportIncidentCu.ClothingBottom1 + "', '" + ReportIncidentCu.Shoes1 + "', '" + ReportIncidentCu.Weapon1 + "', '" + ReportIncidentCu.Gender1 + "', '" + ReportIncidentCu.DistFeat1 + "'," +
                " '" + ReportIncidentCu.InjuryDesc1 + "',  '" + ReportIncidentCu.InjuryCause1 + "',  '" + ReportIncidentCu.InjuryComm1 + "',  '" + ReportIncidentCu.First2 + "',  '" + ReportIncidentCu.Last2 + "', '" + ReportIncidentCu.Contact2 + "', '" + ReportIncidentCu.Type2 + "',  '" + ReportIncidentCu.Witness2 + "'," +
                " '" + ReportIncidentCu.Member2 + "',  '" + ReportIncidentCu.Card2 + "',  '" + ReportIncidentCu.SignInSlip2 + "',  '" + ReportIncidentCu.SignInBy2 + "',  '" + ReportIncidentCu.PDate2 + "'," +
                " '" + ReportIncidentCu.PTimeH2 + "',  '" + ReportIncidentCu.PTimeM2 + "',  '" + ReportIncidentCu.PTimeTC2 + "',  '" + ReportIncidentCu.Age2 + "', '" + ReportIncidentCu.AgeGroup2 + "', '" + ReportIncidentCu.Weight2 + "',  '" + ReportIncidentCu.Height2 + "', '" + ReportIncidentCu.Hair2 + "', '" + ReportIncidentCu.ClothingTop2 + "', '" + ReportIncidentCu.ClothingBottom2 + "', '" + ReportIncidentCu.Shoes2 + "', '" + ReportIncidentCu.Weapon2 + "',  '" + ReportIncidentCu.Gender2 + "',  '" + ReportIncidentCu.DistFeat2 + "'," +
                " '" + ReportIncidentCu.InjuryDesc2 + "',  '" + ReportIncidentCu.InjuryCause2 + "',  '" + ReportIncidentCu.InjuryComm2 + "',  '" + ReportIncidentCu.First3 + "',  '" + ReportIncidentCu.Last3 + "', '" + ReportIncidentCu.Contact3 + "', '" + ReportIncidentCu.Type3 + "',  '" + ReportIncidentCu.Witness3 + "'," +
                " '" + ReportIncidentCu.Member3 + "',  '" + ReportIncidentCu.Card3 + "',  '" + ReportIncidentCu.SignInSlip3 + "',  '" + ReportIncidentCu.SignInBy3 + "',  '" + ReportIncidentCu.PDate3 + "'," +
                " '" + ReportIncidentCu.PTimeH3 + "',  '" + ReportIncidentCu.PTimeM3 + "',  '" + ReportIncidentCu.PTimeTC3 + "',  '" + ReportIncidentCu.Age3 + "', '" + ReportIncidentCu.AgeGroup3 + "', '" + ReportIncidentCu.Weight3 + "',  '" + ReportIncidentCu.Height3 + "', '" + ReportIncidentCu.Hair3 + "', '" + ReportIncidentCu.ClothingTop3 + "', '" + ReportIncidentCu.ClothingBottom3 + "', '" + ReportIncidentCu.Shoes3 + "', '" + ReportIncidentCu.Weapon3 + "',  '" + ReportIncidentCu.Gender3 + "',  '" + ReportIncidentCu.DistFeat3 + "'," +
                " '" + ReportIncidentCu.InjuryDesc3 + "',  '" + ReportIncidentCu.InjuryCause3 + "',  '" + ReportIncidentCu.InjuryComm3 + "',  '" + ReportIncidentCu.First4 + "',  '" + ReportIncidentCu.Last4 + "', '" + ReportIncidentCu.Contact4 + "', '" + ReportIncidentCu.Type4 + "',  '" + ReportIncidentCu.Witness4 + "'," +
                " '" + ReportIncidentCu.Member4 + "',  '" + ReportIncidentCu.Card4 + "',  '" + ReportIncidentCu.SignInSlip4 + "',  '" + ReportIncidentCu.SignInBy4 + "',  '" + ReportIncidentCu.PDate4 + "'," +
                " '" + ReportIncidentCu.PTimeH4 + "',  '" + ReportIncidentCu.PTimeM4 + "',  '" + ReportIncidentCu.PTimeTC4 + "',  '" + ReportIncidentCu.Age4 + "', '" + ReportIncidentCu.AgeGroup4 + "', '" + ReportIncidentCu.Weight4 + "',  '" + ReportIncidentCu.Height4 + "', '" + ReportIncidentCu.Hair4 + "', '" + ReportIncidentCu.ClothingTop4 + "', '" + ReportIncidentCu.ClothingBottom4 + "', '" + ReportIncidentCu.Shoes4 + "', '" + ReportIncidentCu.Weapon4 + "',  '" + ReportIncidentCu.Gender4 + "',  '" + ReportIncidentCu.DistFeat4 + "'," +
                " '" + ReportIncidentCu.InjuryDesc4 + "',  '" + ReportIncidentCu.InjuryCause4 + "',  '" + ReportIncidentCu.InjuryComm4 + "',  '" + ReportIncidentCu.First5 + "',  '" + ReportIncidentCu.Last5 + "', '" + ReportIncidentCu.Contact5 + "', '" + ReportIncidentCu.Type5 + "',  '" + ReportIncidentCu.Witness5 + "'," +
                " '" + ReportIncidentCu.Member5 + "',  '" + ReportIncidentCu.Card5 + "',  '" + ReportIncidentCu.SignInSlip5 + "',  '" + ReportIncidentCu.SignInBy5 + "',  '" + ReportIncidentCu.PDate5 + "'," +
                " '" + ReportIncidentCu.PTimeH5 + "',  '" + ReportIncidentCu.PTimeM5 + "',  '" + ReportIncidentCu.PTimeTC5 + "',  '" + ReportIncidentCu.Age5 + "', '" + ReportIncidentCu.AgeGroup5 + "', '" + ReportIncidentCu.Weight5 + "',  '" + ReportIncidentCu.Height5 + "', '" + ReportIncidentCu.Hair5 + "', '" + ReportIncidentCu.ClothingTop5 + "', '" + ReportIncidentCu.ClothingBottom5 + "', '" + ReportIncidentCu.Shoes5 + "', '" + ReportIncidentCu.Weapon5 + "',  '" + ReportIncidentCu.Gender5 + "',  '" + ReportIncidentCu.DistFeat5 + "'," +
                " '" + ReportIncidentCu.InjuryDesc5 + "',  '" + ReportIncidentCu.InjuryCause5 + "',  '" + ReportIncidentCu.InjuryComm5 + "',  '" + ReportIncidentCu.Date + "',  '" + ReportIncidentCu.Hour + "',  '" + ReportIncidentCu.Minute + "',  '" + ReportIncidentCu.TC + "'," +
                " '" + ReportIncidentCu.Location + "', '" + ReportIncidentCu.LocationOther + "',  '" + ReportIncidentCu.WhatHappened + "', '" + ReportIncidentCu.ActionTaken + "', '" + ReportIncidentCu.ActionTakenOther + "', '" + ReportIncidentCu.Details + "',  '" + ReportIncidentCu.SecurityAttend + "',  '" + ReportIncidentCu.SecurityName + "',  '" + ReportIncidentCu.PoliceNotified + "',  '" + ReportIncidentCu.PoliceAction + "'," +
                " '" + ReportIncidentCu.PoliceStation + "',  '" + ReportIncidentCu.OfficersName + "',  '" + ReportIncidentCu.CamDesc1 + "',  '" + ReportIncidentCu.CamRec1 + "',  '" + ReportIncidentCu.FilePath1 + "',  '" + ReportIncidentCu.SDate1 + "'," +
                " '" + ReportIncidentCu.STimeH1 + "',  '" + ReportIncidentCu.STimeM1 + "',  '" + ReportIncidentCu.STimeTC1 + "',  '" + ReportIncidentCu.EDate1 + "',  '" + ReportIncidentCu.ETimeH1 + "',  '" + ReportIncidentCu.ETimeM1 + "',  '" + ReportIncidentCu.ETimeTC1 + "',  '" + ReportIncidentCu.CamDesc2 + "',  '" + ReportIncidentCu.CamRec2 + "',  '" + ReportIncidentCu.FilePath2 + "',  '" + ReportIncidentCu.SDate2 + "'," +
                " '" + ReportIncidentCu.STimeH2 + "',  '" + ReportIncidentCu.STimeM2 + "',  '" + ReportIncidentCu.STimeTC2 + "',  '" + ReportIncidentCu.EDate2 + "',  '" + ReportIncidentCu.ETimeH2 + "',  '" + ReportIncidentCu.ETimeM2 + "',  '" + ReportIncidentCu.ETimeTC2 + "',  '" + ReportIncidentCu.CamDesc3 + "',  '" + ReportIncidentCu.CamRec3 + "',  '" + ReportIncidentCu.FilePath3 + "',  '" + ReportIncidentCu.SDate3 + "'," +
                " '" + ReportIncidentCu.STimeH3 + "',  '" + ReportIncidentCu.STimeM3 + "',  '" + ReportIncidentCu.STimeTC3 + "',  '" + ReportIncidentCu.EDate3 + "',  '" + ReportIncidentCu.ETimeH3 + "',  '" + ReportIncidentCu.ETimeM3 + "',  '" + ReportIncidentCu.ETimeTC3 + "',  '" + ReportIncidentCu.CamDesc4 + "',  '" + ReportIncidentCu.CamRec4 + "',  '" + ReportIncidentCu.FilePath4 + "',  '" + ReportIncidentCu.SDate4 + "'," +
                " '" + ReportIncidentCu.STimeH4 + "',  '" + ReportIncidentCu.STimeM4 + "',  '" + ReportIncidentCu.STimeTC4 + "',  '" + ReportIncidentCu.EDate4 + "',  '" + ReportIncidentCu.ETimeH4 + "',  '" + ReportIncidentCu.ETimeM4 + "',  '" + ReportIncidentCu.ETimeTC4 + "',  '" + ReportIncidentCu.CamDesc5 + "',  '" + ReportIncidentCu.CamRec5 + "',  '" + ReportIncidentCu.FilePath5 + "',  '" + ReportIncidentCu.SDate5 + "'," +
                " '" + ReportIncidentCu.STimeH5 + "',  '" + ReportIncidentCu.STimeM5 + "',  '" + ReportIncidentCu.STimeTC5 + "',  '" + ReportIncidentCu.EDate5 + "',  '" + ReportIncidentCu.ETimeH5 + "',  '" + ReportIncidentCu.ETimeM5 + "',  '" + ReportIncidentCu.ETimeTC5 + "',  '" + ReportIncidentCu.CamDesc6 + "',  '" + ReportIncidentCu.CamRec6 + "',  '" + ReportIncidentCu.FilePath6 + "',  '" + ReportIncidentCu.SDate6 + "'," +
                " '" + ReportIncidentCu.STimeH6 + "',  '" + ReportIncidentCu.STimeM6 + "',  '" + ReportIncidentCu.STimeTC6 + "',  '" + ReportIncidentCu.EDate6 + "',  '" + ReportIncidentCu.ETimeH6 + "',  '" + ReportIncidentCu.ETimeM6 + "',  '" + ReportIncidentCu.ETimeTC6 + "',  '" + ReportIncidentCu.CamDesc7 + "',  '" + ReportIncidentCu.CamRec7 + "',  '" + ReportIncidentCu.FilePath7 + "',  '" + ReportIncidentCu.SDate7 + "'," +
                " '" + ReportIncidentCu.STimeH7 + "',  '" + ReportIncidentCu.STimeM7 + "',  '" + ReportIncidentCu.STimeTC7 + "',  '" + ReportIncidentCu.EDate7 + "',  '" + ReportIncidentCu.ETimeH7 + "',  '" + ReportIncidentCu.ETimeM7 + "',  '" + ReportIncidentCu.ETimeTC7 + "',  '" + ReportIncidentCu.VDOB1 + "'," +
                " '" + ReportIncidentCu.VAddress1 + "', '" + ReportIncidentCu.VProofID1 + "', '" + ReportIncidentCu.StaffEmp1 + "', '" + ReportIncidentCu.StaffAddress1 + "', '" + ReportIncidentCu.MDOB1 + "', '" + ReportIncidentCu.MAddress1 + "', '" + ReportIncidentCu.VDOB2 + "', '" + ReportIncidentCu.VAddress2 + "'," +
                " '" + ReportIncidentCu.VProofID2 + "', '" + ReportIncidentCu.StaffEmp2 + "', '" + ReportIncidentCu.StaffAddress2 + "', '" + ReportIncidentCu.MDOB2 + "', '" + ReportIncidentCu.MAddress2 + "', '" + ReportIncidentCu.VDOB3 + "', '" + ReportIncidentCu.VAddress3 + "', '" + ReportIncidentCu.VProofID3 + "'," +
                " '" + ReportIncidentCu.StaffEmp3 + "', '" + ReportIncidentCu.StaffAddress3 + "', '" + ReportIncidentCu.MDOB3 + "', '" + ReportIncidentCu.MAddress3 + "', '" + ReportIncidentCu.VDOB4 + "', '" + ReportIncidentCu.VAddress4 + "', '" + ReportIncidentCu.VProofID4 + "', '" + ReportIncidentCu.StaffEmp4 + "'," +
                " '" + ReportIncidentCu.StaffAddress4 + "', '" + ReportIncidentCu.MDOB4 + "', '" + ReportIncidentCu.MAddress4 + "', '" + ReportIncidentCu.VDOB5 + "', '" + ReportIncidentCu.VAddress5 + "', '" + ReportIncidentCu.VProofID5 + "', '" + ReportIncidentCu.StaffEmp5 + "', '" + ReportIncidentCu.StaffAddress5 + "'," +
                " '" + ReportIncidentCu.MDOB5 + "', '" + ReportIncidentCu.MAddress5 + "', '" + ReportIncidentCu.HappenedOther + "', '" + ReportIncidentCu.HappenedSerious + "', '" + ReportIncidentCu.HappenedRefuseEntry + "', '" + ReportIncidentCu.HappenedAskedLeave + "', '" + ReportIncidentCu.Allegation + "', '" + ReportIncidentCu.TxtPartyType1 + "', '" + ReportIncidentCu.TxtPTimeH1 + "', '" + ReportIncidentCu.TxtPTimeM1 + "', '" + ReportIncidentCu.TxtPTimeTC1 + "'," +
                " '" + ReportIncidentCu.TxtGender1 + "', '" + ReportIncidentCu.TxtPartyType2 + "', '" + ReportIncidentCu.TxtPTimeH2 + "', '" + ReportIncidentCu.TxtPTimeM2 + "', '" + ReportIncidentCu.TxtPTimeTC2 + "', '" + ReportIncidentCu.TxtGender2 + "', '" + ReportIncidentCu.TxtPartyType3 + "', '" + ReportIncidentCu.TxtPTimeH3 + "'," +
                " '" + ReportIncidentCu.TxtPTimeM3 + "', '" + ReportIncidentCu.TxtPTimeTC3 + "', '" + ReportIncidentCu.TxtGender3 + "', '" + ReportIncidentCu.TxtPartyType4 + "', '" + ReportIncidentCu.TxtPTimeH4 + "', '" + ReportIncidentCu.TxtPTimeM4 + "', '" + ReportIncidentCu.TxtPTimeTC4 + "', '" + ReportIncidentCu.TxtGender4 + "'," +
                " '" + ReportIncidentCu.TxtPartyType5 + "', '" + ReportIncidentCu.TxtPTimeH5 + "', '" + ReportIncidentCu.TxtPTimeM5 + "', '" + ReportIncidentCu.TxtPTimeTC5 + "', '" + ReportIncidentCu.TxtGender5 + "', '" + ReportIncidentCu.TxtCamSTimeH1 + "', '" + ReportIncidentCu.TxtCamSTimeM1 + "', '" + ReportIncidentCu.TxtCamSTimeTC1 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH1 + "', '" + ReportIncidentCu.TxtCamETimeM1 + "', '" + ReportIncidentCu.TxtCamETimeTC1 + "', '" + ReportIncidentCu.TxtCamSTimeH2 + "', '" + ReportIncidentCu.TxtCamSTimeM2 + "', '" + ReportIncidentCu.TxtCamSTimeTC2 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH2 + "', '" + ReportIncidentCu.TxtCamETimeM2 + "', '" + ReportIncidentCu.TxtCamETimeTC2 + "', '" + ReportIncidentCu.TxtCamSTimeH3 + "', '" + ReportIncidentCu.TxtCamSTimeM3 + "', '" + ReportIncidentCu.TxtCamSTimeTC3 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH3 + "', '" + ReportIncidentCu.TxtCamETimeM3 + "', '" + ReportIncidentCu.TxtCamETimeTC3 + "', '" + ReportIncidentCu.TxtCamSTimeH4 + "', '" + ReportIncidentCu.TxtCamSTimeM4 + "', '" + ReportIncidentCu.TxtCamSTimeTC4 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH4 + "', '" + ReportIncidentCu.TxtCamETimeM4 + "', '" + ReportIncidentCu.TxtCamETimeTC4 + "', '" + ReportIncidentCu.TxtCamSTimeH5 + "', '" + ReportIncidentCu.TxtCamSTimeM5 + "', '" + ReportIncidentCu.TxtCamSTimeTC5 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH5 + "', '" + ReportIncidentCu.TxtCamETimeM5 + "', '" + ReportIncidentCu.TxtCamETimeTC5 + "', '" + ReportIncidentCu.TxtCamSTimeH6 + "', '" + ReportIncidentCu.TxtCamSTimeM6 + "', '" + ReportIncidentCu.TxtCamSTimeTC6 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH6 + "', '" + ReportIncidentCu.TxtCamETimeM6 + "', '" + ReportIncidentCu.TxtCamETimeTC6 + "', '" + ReportIncidentCu.TxtCamSTimeH7 + "', '" + ReportIncidentCu.TxtCamSTimeM7 + "', '" + ReportIncidentCu.TxtCamSTimeTC7 + "'," +
                " '" + ReportIncidentCu.TxtCamETimeH7 + "', '" + ReportIncidentCu.TxtCamETimeM7 + "', '" + ReportIncidentCu.TxtCamETimeTC7 + "', '" + ReportIncidentCu.TxtTimeH + "', '" + ReportIncidentCu.TxtTimeM + "', '" + ReportIncidentCu.TxtTimeTC + "', '" + ReportIncidentCu.PlayerId1 + "', '" + ReportIncidentCu.PlayerId2 + "', '" + ReportIncidentCu.PlayerId3 + "', '" + ReportIncidentCu.PlayerId4 + "', '" + ReportIncidentCu.PlayerId5 + "', '" + ReportIncidentCu.Alias1 + "', '" + ReportIncidentCu.Alias2 + "', '" + ReportIncidentCu.Alias3 + "', '" + ReportIncidentCu.Alias4 + "', '" + ReportIncidentCu.Alias5 + "'," +
                " '" + ReportIncidentCu.MemberSince1 + "', '" + ReportIncidentCu.MemberSince2 + "', '" + ReportIncidentCu.MemberSince3 + "', '" + ReportIncidentCu.MemberSince4 + "', '" + ReportIncidentCu.MemberSince5 + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("CU Duty Managers") && Version.ToString() == "1") // CU Duty Manager Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, Supervisors, Whs, CostSavings, ClubPresent, ClubMaintenance, Absenteeism, StaffIssues, Gaming, KeySecurity, Cameras, GeneralComments," +
                " LuckyRewards, Compliance, LastChanged) VALUES(" + Id + ", 7, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_ClubUminaDutyManager', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportDutyManagerCu.Sup + "', '" + ReportDutyManagerCu.Whs + "', '" + ReportDutyManagerCu.Cost + "', '" + ReportDutyManagerCu.ClubPres + "', '" + ReportDutyManagerCu.ClubMain + "', '" + ReportDutyManagerCu.Absent + "'," +
                " '" + ReportDutyManagerCu.StaffIssues + "', '" + ReportDutyManagerCu.Gaming + "', '" + ReportDutyManagerCu.KeySec + "', '" + ReportDutyManagerCu.Cameras + "', '" + ReportDutyManagerCu.GenComm + "', '" + ReportDutyManagerCu.LuckyRewards + "',  '" + ReportDutyManagerCu.Compliance + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("MR Duty Managers") && Version.ToString() == "1") // MR Duty Manager Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, Supervisors, Whs, CostSavings, ClubPresent, ClubMaintenance, Absenteeism, StaffIssues, Gaming, KeySecurity, Cameras, GeneralComments," +
                " LuckyRewards, Compliance, LastChanged) VALUES(" + Id + ", 2, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLDutyManager', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportDutyManagerMr.Sup + "', '" + ReportDutyManagerMr.Whs + "', '" + ReportDutyManagerMr.Cost + "', '" + ReportDutyManagerMr.ClubPres + "', '" + ReportDutyManagerMr.ClubMain + "', '" + ReportDutyManagerMr.Absent + "'," +
                " '" + ReportDutyManagerMr.StaffIssues + "', '" + ReportDutyManagerMr.Gaming + "', '" + ReportDutyManagerMr.KeySec + "', '" + ReportDutyManagerMr.Cameras + "', '" + ReportDutyManagerMr.GenComm + "', '" + ReportDutyManagerMr.LuckyRewards + "',  '" + ReportDutyManagerMr.Compliance + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("MR Duty Managers") && Version.ToString() == "2") // MR Duty Manager Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, Supervisors, Whs, CostSavings, ClubPresent, ClubMaintenance, Absenteeism, StaffIssues, Gaming, KeySecurity, Cameras" +
                ", LastChanged) VALUES(" + Id + ", 2, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLDutyManager', 2, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportDutyManagerMr.Sup + "', '" + ReportDutyManagerMr.Whs + "', '" + ReportDutyManagerMr.Cost + "', '" + ReportDutyManagerMr.ClubPres + "', '" + ReportDutyManagerMr.ClubMain + "', '" + ReportDutyManagerMr.Absent + "'," +
                " '" + ReportDutyManagerMr.StaffIssues + "', '" + ReportDutyManagerMr.Gaming + "', '" + ReportDutyManagerMr.KeySec + "', '" + ReportDutyManagerMr.Cameras + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("MR Reception") && Version.ToString() == "1") // MR Reception Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, SignInSlip, Refusals, EventsField, GeneralComments, LastChanged) " +
                "VALUES(" + Id + ", 6, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLReception', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportReceptionMr.SignIn + "', '" + ReportReceptionMr.Refusals + "', '" + ReportReceptionMr.Events + "', '" + ReportReceptionMr.GenComm + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("CU Reception") && Version.ToString() == "1") // MR Reception Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, SignInSlip, Refusals, EventsField, GeneralComments, LastChanged) " +
                "VALUES(" + Id + ", 8, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_ClubUminaReception', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportReceptionCu.SignIn + "', '" + ReportReceptionCu.Refusals + "', '" + ReportReceptionCu.Events + "', '" + ReportReceptionCu.GenComm + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("MR Reception Supervisor") && Version.ToString() == "1") // MR Reception Supervisor Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, SignInSlip, Refusals, EventsField, GeneralComments, LastChanged) " +
                "VALUES(" + Id + ", 5, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLReceptionSupervisor', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportReceptionSupervisorMr.SignIn + "', '" + ReportReceptionSupervisorMr.Refusals + "', '" + ReportReceptionSupervisorMr.Events + "', '" + ReportReceptionSupervisorMr.GenComm + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("MR Supervisors") && Version.ToString() == "1") // MR Supervisor Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, SignInSlip, Reception, Gaming, Bar, TABKeno, HouseKeeping, Bistro, FoodHygiene, Events, CustomerService, GeneralComments, LuckyRewards, RSA, AMLCTF, LastChanged) " +
                "VALUES(" + Id + ", 3, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLSupervisor', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportSupervisorMr.SignInSlip + "', '" + ReportSupervisorMr.Reception + "', '" + ReportSupervisorMr.Gaming + "', '" + ReportSupervisorMr.Bar + "', '" + ReportSupervisorMr.TabKeno +
                "', '" + ReportSupervisorMr.HouseKeeping + "', '" + ReportSupervisorMr.Bistro + "', '" + ReportSupervisorMr.FoodHygiene + "', '" + ReportSupervisorMr.Events + "', '" + ReportSupervisorMr.CustomerService + "', '" + ReportSupervisorMr.GenComm + "', '" + ReportSupervisorMr.LuckyRewards + "', '" + ReportSupervisorMr.RSA + "', '" + ReportSupervisorMr.AMLCTF + "', " + UserCredentials.StaffId + ");";
        }

        if (Name.Equals("MR Function Supervisor") && Version.ToString() == "1") // MR Function Supervisor Version 1
        {
            insertQuery = "INSERT INTO " + Table + " (ReportId, RCatId, StaffId, StaffName, ShiftId, ShiftDate, ShiftDOW, EntryDate, AuditVersion, Report_Table, Report_Version, ModifyDate, ReportStat, ReadByList, Comments, FunctionName, NumberOfGuests, Setup, MenuFeedback, BarFeedback, StaffIssues, GeneralComments, LastChanged) " +
                "VALUES(" + Id + ", 4, " + SelectedStaffId + ", '" + SelectedStaffName + "' ," + ShiftId + ", (CONVERT(DateTime,'" + ShiftDate + "',103)), '" + ShiftDOW + "', (CONVERT(DateTime,'" + EntryDate + "',103)), " + AuditVersion + ", 'Report_MerrylandsRSLFunctionSupervisor', 1, current_timestamp, 'Awaiting Completion', ',' + '" + SelectedStaffId + "' + ',', '" + Report.Comment + "', '" + ReportFunctionSupervisorMr.FunctionName + "', '" + ReportFunctionSupervisorMr.NoOfGuests + "', '" + ReportFunctionSupervisorMr.Setup + "', '" + ReportFunctionSupervisorMr.MenuFeed +
                "', '" + ReportFunctionSupervisorMr.BarFeed + "', '" + ReportFunctionSupervisorMr.StaffIss + "', '" + ReportFunctionSupervisorMr.GenComm + "', " + UserCredentials.StaffId + ");";
        }

        return insertQuery;
    }

    // method for setting the appropriate report to update
    public static string UpdateQuery()
    {
        string updateQuery = "";
        if (Name.Equals("MR Incident Report") && Version.ToString() == "1") // MR Incident Report Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', NoOfPerson=" + ReportIncidentMr.NoOfPerson + ", FirstName1='" + ReportIncidentMr.First1 + "', LastName1='" + ReportIncidentMr.Last1 + "', Contact1='" + ReportIncidentMr.Contact1 + "', PartyType1='" + ReportIncidentMr.Type1 + "', Witness1='" + ReportIncidentMr.Witness1 + "'," +
                " MemberNo1='" + ReportIncidentMr.Member1 + "', CardHeld1='" + ReportIncidentMr.Card1 + "', SignInSlip1='" + ReportIncidentMr.SignInSlip1 + "', SignedInBy1='" + ReportIncidentMr.SignInBy1 + "', PDate1='" + ReportIncidentMr.PDate1 + "'," +
                " PTimeH1='" + ReportIncidentMr.PTimeH1 + "', PTimeM1='" + ReportIncidentMr.PTimeM1 + "', PTimeTC1='" + ReportIncidentMr.PTimeTC1 + "', Age1='" + ReportIncidentMr.Age1 + "', AgeGroup1='" + ReportIncidentMr.AgeGroup1 + "', Weight1='" + ReportIncidentMr.Weight1 + "', Height1='" + ReportIncidentMr.Height1 + "', Hair1='" + ReportIncidentMr.Hair1 + "', ClothingTop1='" + ReportIncidentMr.ClothingTop1 + "', ClothingBottom1='" + ReportIncidentMr.ClothingBottom1 + "', Shoes1='" + ReportIncidentMr.Shoes1 + "', Weapon1='" + ReportIncidentMr.Weapon1 + "', Gender1='" + ReportIncidentMr.Gender1 + "', DistFeatures1='" + ReportIncidentMr.DistFeat1 + "'," +
                " InjuryDesc1='" + ReportIncidentMr.InjuryDesc1 + "', CauseInjury1='" + ReportIncidentMr.InjuryCause1 + "', Comments1='" + ReportIncidentMr.InjuryComm1 + "', FirstName2='" + ReportIncidentMr.First2 + "', LastName2='" + ReportIncidentMr.Last2 + "', Contact2='" + ReportIncidentMr.Contact2 + "', PartyType2='" + ReportIncidentMr.Type2 + "', Witness2='" + ReportIncidentMr.Witness2 + "'," +
                " MemberNo2='" + ReportIncidentMr.Member2 + "', CardHeld2='" + ReportIncidentMr.Card2 + "', SignInSlip2='" + ReportIncidentMr.SignInSlip2 + "', SignedInBy2='" + ReportIncidentMr.SignInBy2 + "', PDate2='" + ReportIncidentMr.PDate2 + "'," +
                " PTimeH2='" + ReportIncidentMr.PTimeH2 + "', PTimeM2='" + ReportIncidentMr.PTimeM2 + "', PTimeTC2='" + ReportIncidentMr.PTimeTC2 + "', Age2='" + ReportIncidentMr.Age2 + "', AgeGroup2='" + ReportIncidentMr.AgeGroup2 + "', Weight2='" + ReportIncidentMr.Weight2 + "', Height2='" + ReportIncidentMr.Height2 + "', Hair2='" + ReportIncidentMr.Hair2 + "', ClothingTop2='" + ReportIncidentMr.ClothingTop2 + "', ClothingBottom2='" + ReportIncidentMr.ClothingBottom2 + "', Shoes2='" + ReportIncidentMr.Shoes2 + "', Weapon2='" + ReportIncidentMr.Weapon2 + "', Gender2='" + ReportIncidentMr.Gender2 + "', DistFeatures2='" + ReportIncidentMr.DistFeat2 + "'," +
                " InjuryDesc2='" + ReportIncidentMr.InjuryDesc2 + "', CauseInjury2='" + ReportIncidentMr.InjuryCause2 + "', Comments2='" + ReportIncidentMr.InjuryComm2 + "', FirstName3='" + ReportIncidentMr.First3 + "', LastName3='" + ReportIncidentMr.Last3 + "', Contact3='" + ReportIncidentMr.Contact3 + "', PartyType3='" + ReportIncidentMr.Type3 + "', Witness3='" + ReportIncidentMr.Witness3 + "'," +
                " MemberNo3='" + ReportIncidentMr.Member3 + "', CardHeld3='" + ReportIncidentMr.Card3 + "', SignInSlip3='" + ReportIncidentMr.SignInSlip3 + "', SignedInBy3='" + ReportIncidentMr.SignInBy3 + "', PDate3='" + ReportIncidentMr.PDate3 + "'," +
                " PTimeH3='" + ReportIncidentMr.PTimeH3 + "', PTimeM3='" + ReportIncidentMr.PTimeM3 + "', PTimeTC3='" + ReportIncidentMr.PTimeTC3 + "', Age3='" + ReportIncidentMr.Age3 + "', AgeGroup3='" + ReportIncidentMr.AgeGroup3 + "', Weight3='" + ReportIncidentMr.Weight3 + "', Height3='" + ReportIncidentMr.Height3 + "', Hair3='" + ReportIncidentMr.Hair3 + "', ClothingTop3='" + ReportIncidentMr.ClothingTop3 + "', ClothingBottom3='" + ReportIncidentMr.ClothingBottom3 + "', Shoes3='" + ReportIncidentMr.Shoes3 + "', Weapon3='" + ReportIncidentMr.Weapon3 + "', Gender3='" + ReportIncidentMr.Gender3 + "', DistFeatures3='" + ReportIncidentMr.DistFeat3 + "'," +
                " InjuryDesc3='" + ReportIncidentMr.InjuryDesc3 + "', CauseInjury3='" + ReportIncidentMr.InjuryCause3 + "', Comments3='" + ReportIncidentMr.InjuryComm3 + "', FirstName4='" + ReportIncidentMr.First4 + "', LastName4='" + ReportIncidentMr.Last4 + "', Contact4='" + ReportIncidentMr.Contact4 + "', PartyType4='" + ReportIncidentMr.Type4 + "', Witness4='" + ReportIncidentMr.Witness4 + "'," +
                " MemberNo4='" + ReportIncidentMr.Member4 + "', CardHeld4='" + ReportIncidentMr.Card4 + "', SignInSlip4='" + ReportIncidentMr.SignInSlip4 + "', SignedInBy4='" + ReportIncidentMr.SignInBy4 + "', PDate4='" + ReportIncidentMr.PDate4 + "'," +
                " PTimeH4='" + ReportIncidentMr.PTimeH4 + "', PTimeM4='" + ReportIncidentMr.PTimeM4 + "', PTimeTC4='" + ReportIncidentMr.PTimeTC4 + "', Age4='" + ReportIncidentMr.Age4 + "', AgeGroup4='" + ReportIncidentMr.AgeGroup4 + "', Weight4='" + ReportIncidentMr.Weight4 + "', Height4='" + ReportIncidentMr.Height4 + "', Hair4='" + ReportIncidentMr.Hair4 + "', ClothingTop4='" + ReportIncidentMr.ClothingTop4 + "', ClothingBottom4='" + ReportIncidentMr.ClothingBottom4 + "', Shoes4='" + ReportIncidentMr.Shoes4 + "', Weapon4='" + ReportIncidentMr.Weapon4 + "', Gender4='" + ReportIncidentMr.Gender4 + "', DistFeatures4='" + ReportIncidentMr.DistFeat4 + "'," +
                " InjuryDesc4='" + ReportIncidentMr.InjuryDesc4 + "', CauseInjury4='" + ReportIncidentMr.InjuryCause4 + "', Comments4='" + ReportIncidentMr.InjuryComm4 + "', FirstName5='" + ReportIncidentMr.First5 + "', LastName5='" + ReportIncidentMr.Last5 + "', Contact5='" + ReportIncidentMr.Contact5 + "', PartyType5='" + ReportIncidentMr.Type5 + "', Witness5='" + ReportIncidentMr.Witness5 + "'," +
                " MemberNo5='" + ReportIncidentMr.Member5 + "', CardHeld5='" + ReportIncidentMr.Card5 + "', SignInSlip5='" + ReportIncidentMr.SignInSlip5 + "', SignedInBy5='" + ReportIncidentMr.SignInBy5 + "', PDate5='" + ReportIncidentMr.PDate5 + "'," +
                " PTimeH5='" + ReportIncidentMr.PTimeH5 + "', PTimeM5='" + ReportIncidentMr.PTimeM5 + "', PTimeTC5='" + ReportIncidentMr.PTimeTC5 + "', Age5='" + ReportIncidentMr.Age5 + "', AgeGroup5='" + ReportIncidentMr.AgeGroup5 + "', Weight5='" + ReportIncidentMr.Weight5 + "', Height5='" + ReportIncidentMr.Height5 + "', Hair5='" + ReportIncidentMr.Hair5 + "', ClothingTop5='" + ReportIncidentMr.ClothingTop5 + "', ClothingBottom5='" + ReportIncidentMr.ClothingBottom5 + "', Shoes5='" + ReportIncidentMr.Shoes5 + "', Weapon5='" + ReportIncidentMr.Weapon5 + "', Gender5='" + ReportIncidentMr.Gender5 + "', DistFeatures5='" + ReportIncidentMr.DistFeat5 + "'," +
                " InjuryDesc5='" + ReportIncidentMr.InjuryDesc5 + "', CauseInjury5='" + ReportIncidentMr.InjuryCause5 + "', Comments5='" + ReportIncidentMr.InjuryComm5 + "', Date='" + ReportIncidentMr.Date + "', TimeH='" + ReportIncidentMr.Hour + "', TimeM='" + ReportIncidentMr.Minute + "', TimeTC='" + ReportIncidentMr.TC + "'," +
                " Location = '" + ReportIncidentMr.Location + "', LocationOther='" + ReportIncidentMr.LocationOther + "', IncidentHappened='" + ReportIncidentMr.WhatHappened + "', ActionTaken='" + ReportIncidentMr.ActionTaken + "', ActionTakenOther='" + ReportIncidentMr.ActionTakenOther + "', Details='" + ReportIncidentMr.Details + "', SecurityAttend='" + ReportIncidentMr.SecurityAttend + "', SecurityName='" + ReportIncidentMr.SecurityName + "', PoliceNotify='" + ReportIncidentMr.PoliceNotified + "', PoliceAction='" + ReportIncidentMr.PoliceAction + "'," +
                " PoliceStation='" + ReportIncidentMr.PoliceStation + "', OfficersName='" + ReportIncidentMr.OfficersName + "', CamDesc1='" + ReportIncidentMr.CamDesc1 + "', CamRecorded1='" + ReportIncidentMr.CamRec1 + "', CamFilePath1='" + ReportIncidentMr.FilePath1 + "', CamSDate1='" + ReportIncidentMr.SDate1 + "'," +
                " CamSTimeH1='" + ReportIncidentMr.STimeH1 + "', CamSTimeM1='" + ReportIncidentMr.STimeM1 + "', CamSTimeTC1='" + ReportIncidentMr.STimeTC1 + "', CamEDate1='" + ReportIncidentMr.EDate1 + "', CamETimeH1='" + ReportIncidentMr.ETimeH1 + "', CamETimeM1='" + ReportIncidentMr.ETimeM1 + "', CamETimeTC1='" + ReportIncidentMr.ETimeTC1 + "', CamDesc2='" + ReportIncidentMr.CamDesc2 + "', CamRecorded2='" + ReportIncidentMr.CamRec2 + "', CamFilePath2='" + ReportIncidentMr.FilePath2 + "', CamSDate2='" + ReportIncidentMr.SDate2 + "'," +
                " CamSTimeH2='" + ReportIncidentMr.STimeH2 + "', CamSTimeM2='" + ReportIncidentMr.STimeM2 + "', CamSTimeTC2='" + ReportIncidentMr.STimeTC2 + "', CamEDate2='" + ReportIncidentMr.EDate2 + "', CamETimeH2='" + ReportIncidentMr.ETimeH2 + "', CamETimeM2='" + ReportIncidentMr.ETimeM2 + "', CamETimeTC2='" + ReportIncidentMr.ETimeTC2 + "', CamDesc3='" + ReportIncidentMr.CamDesc3 + "', CamRecorded3='" + ReportIncidentMr.CamRec3 + "', CamFilePath3='" + ReportIncidentMr.FilePath3 + "', CamSDate3='" + ReportIncidentMr.SDate3 + "'," +
                " CamSTimeH3='" + ReportIncidentMr.STimeH3 + "', CamSTimeM3='" + ReportIncidentMr.STimeM3 + "', CamSTimeTC3='" + ReportIncidentMr.STimeTC3 + "', CamEDate3='" + ReportIncidentMr.EDate3 + "', CamETimeH3='" + ReportIncidentMr.ETimeH3 + "', CamETimeM3='" + ReportIncidentMr.ETimeM3 + "', CamETimeTC3='" + ReportIncidentMr.ETimeTC3 + "', CamDesc4='" + ReportIncidentMr.CamDesc4 + "', CamRecorded4='" + ReportIncidentMr.CamRec4 + "', CamFilePath4='" + ReportIncidentMr.FilePath4 + "', CamSDate4='" + ReportIncidentMr.SDate4 + "'," +
                " CamSTimeH4='" + ReportIncidentMr.STimeH4 + "', CamSTimeM4='" + ReportIncidentMr.STimeM4 + "', CamSTimeTC4='" + ReportIncidentMr.STimeTC4 + "', CamEDate4='" + ReportIncidentMr.EDate4 + "', CamETimeH4='" + ReportIncidentMr.ETimeH4 + "', CamETimeM4='" + ReportIncidentMr.ETimeM4 + "', CamETimeTC4='" + ReportIncidentMr.ETimeTC4 + "', CamDesc5='" + ReportIncidentMr.CamDesc5 + "', CamRecorded5='" + ReportIncidentMr.CamRec5 + "', CamFilePath5='" + ReportIncidentMr.FilePath5 + "', CamSDate5='" + ReportIncidentMr.SDate5 + "'," +
                " CamSTimeH5='" + ReportIncidentMr.STimeH5 + "', CamSTimeM5='" + ReportIncidentMr.STimeM5 + "', CamSTimeTC5='" + ReportIncidentMr.STimeTC5 + "', CamEDate5='" + ReportIncidentMr.EDate5 + "', CamETimeH5='" + ReportIncidentMr.ETimeH5 + "', CamETimeM5='" + ReportIncidentMr.ETimeM5 + "', CamETimeTC5='" + ReportIncidentMr.ETimeTC5 + "', CamDesc6='" + ReportIncidentMr.CamDesc6 + "', CamRecorded6='" + ReportIncidentMr.CamRec6 + "', CamFilePath6='" + ReportIncidentMr.FilePath6 + "', CamSDate6='" + ReportIncidentMr.SDate6 + "'," +
                " CamSTimeH6='" + ReportIncidentMr.STimeH6 + "', CamSTimeM6='" + ReportIncidentMr.STimeM6 + "', CamSTimeTC6='" + ReportIncidentMr.STimeTC6 + "', CamEDate6='" + ReportIncidentMr.EDate6 + "', CamETimeH6='" + ReportIncidentMr.ETimeH6 + "', CamETimeM6='" + ReportIncidentMr.ETimeM6 + "', CamETimeTC6='" + ReportIncidentMr.ETimeTC6 + "', CamDesc7='" + ReportIncidentMr.CamDesc7 + "', CamRecorded7='" + ReportIncidentMr.CamRec7 + "', CamFilePath7='" + ReportIncidentMr.FilePath7 + "', CamSDate7='" + ReportIncidentMr.SDate7 + "'," +
                " CamSTimeH7='" + ReportIncidentMr.STimeH7 + "', CamSTimeM7='" + ReportIncidentMr.STimeM7 + "', CamSTimeTC7='" + ReportIncidentMr.STimeTC7 + "', CamEDate7='" + ReportIncidentMr.EDate7 + "', CamETimeH7='" + ReportIncidentMr.ETimeH7 + "', CamETimeM7='" + ReportIncidentMr.ETimeM7 + "', CamETimeTC7='" + ReportIncidentMr.ETimeTC7 + "', VisitorDOB1='" + ReportIncidentMr.VDOB1 +
                "', VisitorAddress1='" + ReportIncidentMr.VAddress1 + "', VisitorProofID1='" + ReportIncidentMr.VProofID1 + "', StaffEmpNo1 ='" + ReportIncidentMr.StaffEmp1 + "', StaffAddress1='" + ReportIncidentMr.StaffAddress1 + "', MemberDOB1='" + ReportIncidentMr.MDOB1 + "', MemberAddress1='" + ReportIncidentMr.MAddress1 + "', VisitorDOB2='" + ReportIncidentMr.VDOB2 + "', VisitorAddress2='" + ReportIncidentMr.VAddress2 +
                "', VisitorProofID2='" + ReportIncidentMr.VProofID2 + "', StaffEmpNo2 ='" + ReportIncidentMr.StaffEmp2 + "', StaffAddress2='" + ReportIncidentMr.StaffAddress2 + "', MemberDOB2='" + ReportIncidentMr.MDOB2 + "', MemberAddress2='" + ReportIncidentMr.MAddress2 + "', VisitorDOB3='" + ReportIncidentMr.VDOB3 + "', VisitorAddress3='" + ReportIncidentMr.VAddress3 + "', VisitorProofID3='" + ReportIncidentMr.VProofID3 +
                "', StaffEmpNo3 ='" + ReportIncidentMr.StaffEmp3 + "', StaffAddress3='" + ReportIncidentMr.StaffAddress3 + "', MemberDOB3='" + ReportIncidentMr.MDOB3 + "', MemberAddress3='" + ReportIncidentMr.MAddress3 + "', VisitorDOB4='" + ReportIncidentMr.VDOB4 + "', VisitorAddress4='" + ReportIncidentMr.VAddress4 + "', VisitorProofID4='" + ReportIncidentMr.VProofID4 + "', StaffEmpNo4 ='" + ReportIncidentMr.StaffEmp4 +
                "', StaffAddress4='" + ReportIncidentMr.StaffAddress4 + "', MemberDOB4='" + ReportIncidentMr.MDOB4 + "', MemberAddress4='" + ReportIncidentMr.MAddress4 + "', VisitorDOB5='" + ReportIncidentMr.VDOB5 + "', VisitorAddress5='" + ReportIncidentMr.VAddress5 + "', VisitorProofID5='" + ReportIncidentMr.VProofID5 + "', StaffEmpNo5 ='" + ReportIncidentMr.StaffEmp5 + "', StaffAddress5='" + ReportIncidentMr.StaffAddress5 +
                "', MemberDOB5='" + ReportIncidentMr.MDOB5 + "', MemberAddress5='" + ReportIncidentMr.MAddress5 + "', HappenedOther='" + ReportIncidentMr.HappenedOther + "', HappenedSerious='" + ReportIncidentMr.HappenedSerious + "', HappenedRefuseEntry='" + ReportIncidentMr.HappenedRefuseEntry + "', HappenedAskedToLeave='" + ReportIncidentMr.HappenedAskedLeave + "', Allegation='" + ReportIncidentMr.Allegation + "', TxtPartyType1='" + ReportIncidentMr.TxtPartyType1 + "', TxtPTimeH1='" + ReportIncidentMr.TxtPTimeH1 + "', TxtPTimeM1='" + ReportIncidentMr.TxtPTimeM1 + "', TxtPTimeTC1='" + ReportIncidentMr.TxtPTimeTC1 +
                "', TxtGender1='" + ReportIncidentMr.TxtGender1 + "', TxtPartyType2='" + ReportIncidentMr.TxtPartyType2 + "', TxtPTimeH2='" + ReportIncidentMr.TxtPTimeH2 + "', TxtPTimeM2='" + ReportIncidentMr.TxtPTimeM2 + "', TxtPTimeTC2='" + ReportIncidentMr.TxtPTimeTC2 + "', TxtGender2='" + ReportIncidentMr.TxtGender2 + "', TxtPartyType3='" + ReportIncidentMr.TxtPartyType3 + "', TxtPTimeH3='" + ReportIncidentMr.TxtPTimeH3 +
                "', TxtPTimeM3='" + ReportIncidentMr.TxtPTimeM3 + "', TxtPTimeTC3='" + ReportIncidentMr.TxtPTimeTC3 + "', TxtGender3='" + ReportIncidentMr.TxtGender3 + "', TxtPartyType4='" + ReportIncidentMr.TxtPartyType4 + "', TxtPTimeH4='" + ReportIncidentMr.TxtPTimeH4 + "', TxtPTimeM4='" + ReportIncidentMr.TxtPTimeM4 + "', TxtPTimeTC4='" + ReportIncidentMr.TxtPTimeTC4 + "', TxtGender4='" + ReportIncidentMr.TxtGender4 +
                "', TxtPartyType5='" + ReportIncidentMr.TxtPartyType5 + "', TxtPTimeH5='" + ReportIncidentMr.TxtPTimeH5 + "', TxtPTimeM5='" + ReportIncidentMr.TxtPTimeM5 + "', TxtPTimeTC5='" + ReportIncidentMr.TxtPTimeTC5 + "', TxtGender5='" + ReportIncidentMr.TxtGender5 + "', TxtCamSTimeH1='" + ReportIncidentMr.TxtCamSTimeH1 + "', TxtCamSTimeM1='" + ReportIncidentMr.TxtCamSTimeM1 + "', TxtCamSTimeTC1='" + ReportIncidentMr.TxtCamSTimeTC1 +
                "', TxtCamETimeH1='" + ReportIncidentMr.TxtCamETimeH1 + "', TxtCamETimeM1='" + ReportIncidentMr.TxtCamETimeM1 + "', TxtCamETimeTC1='" + ReportIncidentMr.TxtCamETimeTC1 + "', TxtCamSTimeH2='" + ReportIncidentMr.TxtCamSTimeH2 + "', TxtCamSTimeM2='" + ReportIncidentMr.TxtCamSTimeM2 + "', TxtCamSTimeTC2='" + ReportIncidentMr.TxtCamSTimeTC2 +
                "', TxtCamETimeH2='" + ReportIncidentMr.TxtCamETimeH2 + "', TxtCamETimeM2='" + ReportIncidentMr.TxtCamETimeM2 + "', TxtCamETimeTC2='" + ReportIncidentMr.TxtCamETimeTC2 + "', TxtCamSTimeH3='" + ReportIncidentMr.TxtCamSTimeH3 + "', TxtCamSTimeM3='" + ReportIncidentMr.TxtCamSTimeM3 + "', TxtCamSTimeTC3='" + ReportIncidentMr.TxtCamSTimeTC3 +
                "', TxtCamETimeH3='" + ReportIncidentMr.TxtCamETimeH3 + "', TxtCamETimeM3='" + ReportIncidentMr.TxtCamETimeM3 + "', TxtCamETimeTC3='" + ReportIncidentMr.TxtCamETimeTC3 + "', TxtCamSTimeH4='" + ReportIncidentMr.TxtCamSTimeH4 + "', TxtCamSTimeM4='" + ReportIncidentMr.TxtCamSTimeM4 + "', TxtCamSTimeTC4='" + ReportIncidentMr.TxtCamSTimeTC4 +
                "', TxtCamETimeH4='" + ReportIncidentMr.TxtCamETimeH4 + "', TxtCamETimeM4='" + ReportIncidentMr.TxtCamETimeM4 + "', TxtCamETimeTC4='" + ReportIncidentMr.TxtCamETimeTC4 + "', TxtCamSTimeH5='" + ReportIncidentMr.TxtCamSTimeH5 + "', TxtCamSTimeM5='" + ReportIncidentMr.TxtCamSTimeM5 + "', TxtCamSTimeTC5='" + ReportIncidentMr.TxtCamSTimeTC5 +
                "', TxtCamETimeH5='" + ReportIncidentMr.TxtCamETimeH5 + "', TxtCamETimeM5='" + ReportIncidentMr.TxtCamETimeM5 + "', TxtCamETimeTC5='" + ReportIncidentMr.TxtCamETimeTC5 + "', TxtCamSTimeH6='" + ReportIncidentMr.TxtCamSTimeH6 + "', TxtCamSTimeM6='" + ReportIncidentMr.TxtCamSTimeM6 + "', TxtCamSTimeTC6='" + ReportIncidentMr.TxtCamSTimeTC6 +
                "', TxtCamETimeH6='" + ReportIncidentMr.TxtCamETimeH6 + "', TxtCamETimeM6='" + ReportIncidentMr.TxtCamETimeM6 + "', TxtCamETimeTC6='" + ReportIncidentMr.TxtCamETimeTC6 + "', TxtCamSTimeH7='" + ReportIncidentMr.TxtCamSTimeH7 + "', TxtCamSTimeM7='" + ReportIncidentMr.TxtCamSTimeM7 + "', TxtCamSTimeTC7='" + ReportIncidentMr.TxtCamSTimeTC7 +
                "', TxtCamETimeH7='" + ReportIncidentMr.TxtCamETimeH7 + "', TxtCamETimeM7='" + ReportIncidentMr.TxtCamETimeM7 + "', TxtCamETimeTC7='" + ReportIncidentMr.TxtCamETimeTC7 + "', TxtTimeH='" + ReportIncidentMr.TxtTimeH + "', TxtTimeM='" + ReportIncidentMr.TxtTimeM + "', TxtTimeTC='" + ReportIncidentMr.TxtTimeTC + "', PlayerId1='" + ReportIncidentMr.PlayerId1 +
                "', PlayerId2='" + ReportIncidentMr.PlayerId2 + "', PlayerId3='" + ReportIncidentMr.PlayerId3 + "', PlayerId4='" + ReportIncidentMr.PlayerId4 + "', PlayerId5='" + ReportIncidentMr.PlayerId5 + "', Alias1='" + ReportIncidentMr.Alias1 + "', Alias2='" + ReportIncidentMr.Alias2 + "', Alias3='" + ReportIncidentMr.Alias3 + "', Alias4='" + ReportIncidentMr.Alias4 +
                "', Alias5='" + ReportIncidentMr.Alias5 + "', MemberSince1='" + ReportIncidentMr.MemberSince1 + "', MemberSince2='" + ReportIncidentMr.MemberSince2 + "', MemberSince3='" + ReportIncidentMr.MemberSince3 + "', MemberSince4='" + ReportIncidentMr.MemberSince4 + "', MemberSince5='" + ReportIncidentMr.MemberSince5 + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("CU Incident Report") && Version.ToString() == "1") // UM Incident Report Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', NoOfPerson=" + ReportIncidentCu.NoOfPerson + ", FirstName1='" + ReportIncidentCu.First1 + "', LastName1='" + ReportIncidentCu.Last1 + "', Contact1='" + ReportIncidentCu.Contact1 + "', PartyType1='" + ReportIncidentCu.Type1 + "', Witness1='" + ReportIncidentCu.Witness1 + "'," +
                " MemberNo1='" + ReportIncidentCu.Member1 + "', CardHeld1='" + ReportIncidentCu.Card1 + "', SignInSlip1='" + ReportIncidentCu.SignInSlip1 + "', SignedInBy1='" + ReportIncidentCu.SignInBy1 + "', PDate1='" + ReportIncidentCu.PDate1 + "'," +
                " PTimeH1='" + ReportIncidentCu.PTimeH1 + "', PTimeM1='" + ReportIncidentCu.PTimeM1 + "', PTimeTC1='" + ReportIncidentCu.PTimeTC1 + "', Age1='" + ReportIncidentCu.Age1 + "', AgeGroup1='" + ReportIncidentCu.AgeGroup1 + "', Weight1='" + ReportIncidentCu.Weight1 + "', Height1='" + ReportIncidentCu.Height1 + "', Hair1='" + ReportIncidentCu.Hair1 + "', ClothingTop1='" + ReportIncidentCu.ClothingTop1 + "', ClothingBottom1='" + ReportIncidentCu.ClothingBottom1 + "', Shoes1='" + ReportIncidentCu.Shoes1 + "', Weapon1='" + ReportIncidentCu.Weapon1 + "', Gender1='" + ReportIncidentCu.Gender1 + "', DistFeatures1='" + ReportIncidentCu.DistFeat1 + "'," +
                " InjuryDesc1='" + ReportIncidentCu.InjuryDesc1 + "', CauseInjury1='" + ReportIncidentCu.InjuryCause1 + "', Comments1='" + ReportIncidentCu.InjuryComm1 + "', FirstName2='" + ReportIncidentCu.First2 + "', LastName2='" + ReportIncidentCu.Last2 + "', Contact2='" + ReportIncidentCu.Contact2 + "', PartyType2='" + ReportIncidentCu.Type2 + "', Witness2='" + ReportIncidentCu.Witness2 + "'," +
                " MemberNo2='" + ReportIncidentCu.Member2 + "', CardHeld2='" + ReportIncidentCu.Card2 + "', SignInSlip2='" + ReportIncidentCu.SignInSlip2 + "', SignedInBy2='" + ReportIncidentCu.SignInBy2 + "', PDate2='" + ReportIncidentCu.PDate2 + "'," +
                " PTimeH2='" + ReportIncidentCu.PTimeH2 + "', PTimeM2='" + ReportIncidentCu.PTimeM2 + "', PTimeTC2='" + ReportIncidentCu.PTimeTC2 + "', Age2='" + ReportIncidentCu.Age2 + "', AgeGroup2='" + ReportIncidentCu.AgeGroup2 + "', Weight2='" + ReportIncidentCu.Weight2 + "', Height2='" + ReportIncidentCu.Height2 + "', Hair2='" + ReportIncidentCu.Hair2 + "', ClothingTop2='" + ReportIncidentCu.ClothingTop2 + "', ClothingBottom2='" + ReportIncidentCu.ClothingBottom2 + "', Shoes2='" + ReportIncidentCu.Shoes2 + "', Weapon2='" + ReportIncidentCu.Weapon2 + "', Gender2='" + ReportIncidentCu.Gender2 + "', DistFeatures2='" + ReportIncidentCu.DistFeat2 + "'," +
                " InjuryDesc2='" + ReportIncidentCu.InjuryDesc2 + "', CauseInjury2='" + ReportIncidentCu.InjuryCause2 + "', Comments2='" + ReportIncidentCu.InjuryComm2 + "', FirstName3='" + ReportIncidentCu.First3 + "', LastName3='" + ReportIncidentCu.Last3 + "', Contact3='" + ReportIncidentCu.Contact3 + "', PartyType3='" + ReportIncidentCu.Type3 + "', Witness3='" + ReportIncidentCu.Witness3 + "'," +
                " MemberNo3='" + ReportIncidentCu.Member3 + "', CardHeld3='" + ReportIncidentCu.Card3 + "', SignInSlip3='" + ReportIncidentCu.SignInSlip3 + "', SignedInBy3='" + ReportIncidentCu.SignInBy3 + "', PDate3='" + ReportIncidentCu.PDate3 + "'," +
                " PTimeH3='" + ReportIncidentCu.PTimeH3 + "', PTimeM3='" + ReportIncidentCu.PTimeM3 + "', PTimeTC3='" + ReportIncidentCu.PTimeTC3 + "', Age3='" + ReportIncidentCu.Age3 + "', AgeGroup3='" + ReportIncidentCu.AgeGroup3 + "', Weight3='" + ReportIncidentCu.Weight3 + "', Height3='" + ReportIncidentCu.Height3 + "', Hair3='" + ReportIncidentCu.Hair3 + "', ClothingTop3='" + ReportIncidentCu.ClothingTop3 + "', ClothingBottom3='" + ReportIncidentCu.ClothingBottom3 + "', Shoes3='" + ReportIncidentCu.Shoes3 + "', Weapon3='" + ReportIncidentCu.Weapon3 + "', Gender3='" + ReportIncidentCu.Gender3 + "', DistFeatures3='" + ReportIncidentCu.DistFeat3 + "'," +
                " InjuryDesc3='" + ReportIncidentCu.InjuryDesc3 + "', CauseInjury3='" + ReportIncidentCu.InjuryCause3 + "', Comments3='" + ReportIncidentCu.InjuryComm3 + "', FirstName4='" + ReportIncidentCu.First4 + "', LastName4='" + ReportIncidentCu.Last4 + "', Contact4='" + ReportIncidentCu.Contact4 + "', PartyType4='" + ReportIncidentCu.Type4 + "', Witness4='" + ReportIncidentCu.Witness4 + "'," +
                " MemberNo4='" + ReportIncidentCu.Member4 + "', CardHeld4='" + ReportIncidentCu.Card4 + "', SignInSlip4='" + ReportIncidentCu.SignInSlip4 + "', SignedInBy4='" + ReportIncidentCu.SignInBy4 + "', PDate4='" + ReportIncidentCu.PDate4 + "'," +
                " PTimeH4='" + ReportIncidentCu.PTimeH4 + "', PTimeM4='" + ReportIncidentCu.PTimeM4 + "', PTimeTC4='" + ReportIncidentCu.PTimeTC4 + "', Age4='" + ReportIncidentCu.Age4 + "', AgeGroup4='" + ReportIncidentCu.AgeGroup4 + "', Weight4='" + ReportIncidentCu.Weight4 + "', Height4='" + ReportIncidentCu.Height4 + "', Hair4='" + ReportIncidentCu.Hair4 + "', ClothingTop4='" + ReportIncidentCu.ClothingTop4 + "', ClothingBottom4='" + ReportIncidentCu.ClothingBottom4 + "', Shoes4='" + ReportIncidentCu.Shoes4 + "', Weapon4='" + ReportIncidentCu.Weapon4 + "', Gender4='" + ReportIncidentCu.Gender4 + "', DistFeatures4='" + ReportIncidentCu.DistFeat4 + "'," +
                " InjuryDesc4='" + ReportIncidentCu.InjuryDesc4 + "', CauseInjury4='" + ReportIncidentCu.InjuryCause4 + "', Comments4='" + ReportIncidentCu.InjuryComm4 + "', FirstName5='" + ReportIncidentCu.First5 + "', LastName5='" + ReportIncidentCu.Last5 + "', Contact5='" + ReportIncidentCu.Contact5 + "', PartyType5='" + ReportIncidentCu.Type5 + "', Witness5='" + ReportIncidentCu.Witness5 + "'," +
                " MemberNo5='" + ReportIncidentCu.Member5 + "', CardHeld5='" + ReportIncidentCu.Card5 + "', SignInSlip5='" + ReportIncidentCu.SignInSlip5 + "', SignedInBy5='" + ReportIncidentCu.SignInBy5 + "', PDate5='" + ReportIncidentCu.PDate5 + "'," +
                " PTimeH5='" + ReportIncidentCu.PTimeH5 + "', PTimeM5='" + ReportIncidentCu.PTimeM5 + "', PTimeTC5='" + ReportIncidentCu.PTimeTC5 + "', Age5='" + ReportIncidentCu.Age5 + "', AgeGroup5='" + ReportIncidentCu.AgeGroup5 + "', Weight5='" + ReportIncidentCu.Weight5 + "', Height5='" + ReportIncidentCu.Height5 + "', Hair5='" + ReportIncidentCu.Hair5 + "', ClothingTop5='" + ReportIncidentCu.ClothingTop5 + "', ClothingBottom5='" + ReportIncidentCu.ClothingBottom5 + "', Shoes5='" + ReportIncidentCu.Shoes5 + "', Weapon5='" + ReportIncidentCu.Weapon5 + "', Gender5='" + ReportIncidentCu.Gender5 + "', DistFeatures5='" + ReportIncidentCu.DistFeat5 + "'," +
                " InjuryDesc5='" + ReportIncidentCu.InjuryDesc5 + "', CauseInjury5='" + ReportIncidentCu.InjuryCause5 + "', Comments5='" + ReportIncidentCu.InjuryComm5 + "', Date='" + ReportIncidentCu.Date + "', TimeH='" + ReportIncidentCu.Hour + "', TimeM='" + ReportIncidentCu.Minute + "', TimeTC='" + ReportIncidentCu.TC + "'," +
                " Location = '" + ReportIncidentCu.Location + "', LocationOther='" + ReportIncidentCu.LocationOther + "', IncidentHappened='" + ReportIncidentCu.WhatHappened + "', ActionTaken='" + ReportIncidentCu.ActionTaken + "', ActionTakenOther='" + ReportIncidentCu.ActionTakenOther + "', Details='" + ReportIncidentCu.Details + "', SecurityAttend='" + ReportIncidentCu.SecurityAttend + "', SecurityName='" + ReportIncidentCu.SecurityName + "', PoliceNotify='" + ReportIncidentCu.PoliceNotified + "', PoliceAction='" + ReportIncidentCu.PoliceAction + "'," +
                " PoliceStation='" + ReportIncidentCu.PoliceStation + "', OfficersName='" + ReportIncidentCu.OfficersName + "', CamDesc1='" + ReportIncidentCu.CamDesc1 + "', CamRecorded1='" + ReportIncidentCu.CamRec1 + "', CamFilePath1='" + ReportIncidentCu.FilePath1 + "', CamSDate1='" + ReportIncidentCu.SDate1 + "'," +
                " CamSTimeH1='" + ReportIncidentCu.STimeH1 + "', CamSTimeM1='" + ReportIncidentCu.STimeM1 + "', CamSTimeTC1='" + ReportIncidentCu.STimeTC1 + "', CamEDate1='" + ReportIncidentCu.EDate1 + "', CamETimeH1='" + ReportIncidentCu.ETimeH1 + "', CamETimeM1='" + ReportIncidentCu.ETimeM1 + "', CamETimeTC1='" + ReportIncidentCu.ETimeTC1 + "', CamDesc2='" + ReportIncidentCu.CamDesc2 + "', CamRecorded2='" + ReportIncidentCu.CamRec2 + "', CamFilePath2='" + ReportIncidentCu.FilePath2 + "', CamSDate2='" + ReportIncidentCu.SDate2 + "'," +
                " CamSTimeH2='" + ReportIncidentCu.STimeH2 + "', CamSTimeM2='" + ReportIncidentCu.STimeM2 + "', CamSTimeTC2='" + ReportIncidentCu.STimeTC2 + "', CamEDate2='" + ReportIncidentCu.EDate2 + "', CamETimeH2='" + ReportIncidentCu.ETimeH2 + "', CamETimeM2='" + ReportIncidentCu.ETimeM2 + "', CamETimeTC2='" + ReportIncidentCu.ETimeTC2 + "', CamDesc3='" + ReportIncidentCu.CamDesc3 + "', CamRecorded3='" + ReportIncidentCu.CamRec3 + "', CamFilePath3='" + ReportIncidentCu.FilePath3 + "', CamSDate3='" + ReportIncidentCu.SDate3 + "'," +
                " CamSTimeH3='" + ReportIncidentCu.STimeH3 + "', CamSTimeM3='" + ReportIncidentCu.STimeM3 + "', CamSTimeTC3='" + ReportIncidentCu.STimeTC3 + "', CamEDate3='" + ReportIncidentCu.EDate3 + "', CamETimeH3='" + ReportIncidentCu.ETimeH3 + "', CamETimeM3='" + ReportIncidentCu.ETimeM3 + "', CamETimeTC3='" + ReportIncidentCu.ETimeTC3 + "', CamDesc4='" + ReportIncidentCu.CamDesc4 + "', CamRecorded4='" + ReportIncidentCu.CamRec4 + "', CamFilePath4='" + ReportIncidentCu.FilePath4 + "', CamSDate4='" + ReportIncidentCu.SDate4 + "'," +
                " CamSTimeH4='" + ReportIncidentCu.STimeH4 + "', CamSTimeM4='" + ReportIncidentCu.STimeM4 + "', CamSTimeTC4='" + ReportIncidentCu.STimeTC4 + "', CamEDate4='" + ReportIncidentCu.EDate4 + "', CamETimeH4='" + ReportIncidentCu.ETimeH4 + "', CamETimeM4='" + ReportIncidentCu.ETimeM4 + "', CamETimeTC4='" + ReportIncidentCu.ETimeTC4 + "', CamDesc5='" + ReportIncidentCu.CamDesc5 + "', CamRecorded5='" + ReportIncidentCu.CamRec5 + "', CamFilePath5='" + ReportIncidentCu.FilePath5 + "', CamSDate5='" + ReportIncidentCu.SDate5 + "'," +
                " CamSTimeH5='" + ReportIncidentCu.STimeH5 + "', CamSTimeM5='" + ReportIncidentCu.STimeM5 + "', CamSTimeTC5='" + ReportIncidentCu.STimeTC5 + "', CamEDate5='" + ReportIncidentCu.EDate5 + "', CamETimeH5='" + ReportIncidentCu.ETimeH5 + "', CamETimeM5='" + ReportIncidentCu.ETimeM5 + "', CamETimeTC5='" + ReportIncidentCu.ETimeTC5 + "', CamDesc6='" + ReportIncidentCu.CamDesc6 + "', CamRecorded6='" + ReportIncidentCu.CamRec6 + "', CamFilePath6='" + ReportIncidentCu.FilePath6 + "', CamSDate6='" + ReportIncidentCu.SDate6 + "'," +
                " CamSTimeH6='" + ReportIncidentCu.STimeH6 + "', CamSTimeM6='" + ReportIncidentCu.STimeM6 + "', CamSTimeTC6='" + ReportIncidentCu.STimeTC6 + "', CamEDate6='" + ReportIncidentCu.EDate6 + "', CamETimeH6='" + ReportIncidentCu.ETimeH6 + "', CamETimeM6='" + ReportIncidentCu.ETimeM6 + "', CamETimeTC6='" + ReportIncidentCu.ETimeTC6 + "', CamDesc7='" + ReportIncidentCu.CamDesc7 + "', CamRecorded7='" + ReportIncidentCu.CamRec7 + "', CamFilePath7='" + ReportIncidentCu.FilePath7 + "', CamSDate7='" + ReportIncidentCu.SDate7 + "'," +
                " CamSTimeH7='" + ReportIncidentCu.STimeH7 + "', CamSTimeM7='" + ReportIncidentCu.STimeM7 + "', CamSTimeTC7='" + ReportIncidentCu.STimeTC7 + "', CamEDate7='" + ReportIncidentCu.EDate7 + "', CamETimeH7='" + ReportIncidentCu.ETimeH7 + "', CamETimeM7='" + ReportIncidentCu.ETimeM7 + "', CamETimeTC7='" + ReportIncidentCu.ETimeTC7 + "', VisitorDOB1='" + ReportIncidentCu.VDOB1 +
                "', VisitorAddress1='" + ReportIncidentCu.VAddress1 + "', VisitorProofID1='" + ReportIncidentCu.VProofID1 + "', StaffEmpNo1 ='" + ReportIncidentCu.StaffEmp1 + "', StaffAddress1='" + ReportIncidentCu.StaffAddress1 + "', MemberDOB1='" + ReportIncidentCu.MDOB1 + "', MemberAddress1='" + ReportIncidentCu.MAddress1 + "', VisitorDOB2='" + ReportIncidentCu.VDOB2 + "', VisitorAddress2='" + ReportIncidentCu.VAddress2 +
                "', VisitorProofID2='" + ReportIncidentCu.VProofID2 + "', StaffEmpNo2 ='" + ReportIncidentCu.StaffEmp2 + "', StaffAddress2='" + ReportIncidentCu.StaffAddress2 + "', MemberDOB2='" + ReportIncidentCu.MDOB2 + "', MemberAddress2='" + ReportIncidentCu.MAddress2 + "', VisitorDOB3='" + ReportIncidentCu.VDOB3 + "', VisitorAddress3='" + ReportIncidentCu.VAddress3 + "', VisitorProofID3='" + ReportIncidentCu.VProofID3 +
                "', StaffEmpNo3 ='" + ReportIncidentCu.StaffEmp3 + "', StaffAddress3='" + ReportIncidentCu.StaffAddress3 + "', MemberDOB3='" + ReportIncidentCu.MDOB3 + "', MemberAddress3='" + ReportIncidentCu.MAddress3 + "', VisitorDOB4='" + ReportIncidentCu.VDOB4 + "', VisitorAddress4='" + ReportIncidentCu.VAddress4 + "', VisitorProofID4='" + ReportIncidentCu.VProofID4 + "', StaffEmpNo4 ='" + ReportIncidentCu.StaffEmp4 +
                "', StaffAddress4='" + ReportIncidentCu.StaffAddress4 + "', MemberDOB4='" + ReportIncidentCu.MDOB4 + "', MemberAddress4='" + ReportIncidentCu.MAddress4 + "', VisitorDOB5='" + ReportIncidentCu.VDOB5 + "', VisitorAddress5='" + ReportIncidentCu.VAddress5 + "', VisitorProofID5='" + ReportIncidentCu.VProofID5 + "', StaffEmpNo5 ='" + ReportIncidentCu.StaffEmp5 + "', StaffAddress5='" + ReportIncidentCu.StaffAddress5 +
                "', MemberDOB5='" + ReportIncidentCu.MDOB5 + "', MemberAddress5='" + ReportIncidentCu.MAddress5 + "', HappenedOther='" + ReportIncidentCu.HappenedOther + "', HappenedSerious='" + ReportIncidentCu.HappenedSerious + "', HappenedRefuseEntry='" + ReportIncidentCu.HappenedRefuseEntry + "', HappenedAskedToLeave='" + ReportIncidentCu.HappenedAskedLeave + "', Allegation='" + ReportIncidentCu.Allegation + "', TxtPartyType1='" + ReportIncidentCu.TxtPartyType1 + "', TxtPTimeH1='" + ReportIncidentCu.TxtPTimeH1 + "', TxtPTimeM1='" + ReportIncidentCu.TxtPTimeM1 + "', TxtPTimeTC1='" + ReportIncidentCu.TxtPTimeTC1 +
                "', TxtGender1='" + ReportIncidentCu.TxtGender1 + "', TxtPartyType2='" + ReportIncidentCu.TxtPartyType2 + "', TxtPTimeH2='" + ReportIncidentCu.TxtPTimeH2 + "', TxtPTimeM2='" + ReportIncidentCu.TxtPTimeM2 + "', TxtPTimeTC2='" + ReportIncidentCu.TxtPTimeTC2 + "', TxtGender2='" + ReportIncidentCu.TxtGender2 + "', TxtPartyType3='" + ReportIncidentCu.TxtPartyType3 + "', TxtPTimeH3='" + ReportIncidentCu.TxtPTimeH3 +
                "', TxtPTimeM3='" + ReportIncidentCu.TxtPTimeM3 + "', TxtPTimeTC3='" + ReportIncidentCu.TxtPTimeTC3 + "', TxtGender3='" + ReportIncidentCu.TxtGender3 + "', TxtPartyType4='" + ReportIncidentCu.TxtPartyType4 + "', TxtPTimeH4='" + ReportIncidentCu.TxtPTimeH4 + "', TxtPTimeM4='" + ReportIncidentCu.TxtPTimeM4 + "', TxtPTimeTC4='" + ReportIncidentCu.TxtPTimeTC4 + "', TxtGender4='" + ReportIncidentCu.TxtGender4 +
                "', TxtPartyType5='" + ReportIncidentCu.TxtPartyType5 + "', TxtPTimeH5='" + ReportIncidentCu.TxtPTimeH5 + "', TxtPTimeM5='" + ReportIncidentCu.TxtPTimeM5 + "', TxtPTimeTC5='" + ReportIncidentCu.TxtPTimeTC5 + "', TxtGender5='" + ReportIncidentCu.TxtGender5 + "', TxtCamSTimeH1='" + ReportIncidentCu.TxtCamSTimeH1 + "', TxtCamSTimeM1='" + ReportIncidentCu.TxtCamSTimeM1 + "', TxtCamSTimeTC1='" + ReportIncidentCu.TxtCamSTimeTC1 +
                "', TxtCamETimeH1='" + ReportIncidentCu.TxtCamETimeH1 + "', TxtCamETimeM1='" + ReportIncidentCu.TxtCamETimeM1 + "', TxtCamETimeTC1='" + ReportIncidentCu.TxtCamETimeTC1 + "', TxtCamSTimeH2='" + ReportIncidentCu.TxtCamSTimeH2 + "', TxtCamSTimeM2='" + ReportIncidentCu.TxtCamSTimeM2 + "', TxtCamSTimeTC2='" + ReportIncidentCu.TxtCamSTimeTC2 +
                "', TxtCamETimeH2='" + ReportIncidentCu.TxtCamETimeH2 + "', TxtCamETimeM2='" + ReportIncidentCu.TxtCamETimeM2 + "', TxtCamETimeTC2='" + ReportIncidentCu.TxtCamETimeTC2 + "', TxtCamSTimeH3='" + ReportIncidentCu.TxtCamSTimeH3 + "', TxtCamSTimeM3='" + ReportIncidentCu.TxtCamSTimeM3 + "', TxtCamSTimeTC3='" + ReportIncidentCu.TxtCamSTimeTC3 +
                "', TxtCamETimeH3='" + ReportIncidentCu.TxtCamETimeH3 + "', TxtCamETimeM3='" + ReportIncidentCu.TxtCamETimeM3 + "', TxtCamETimeTC3='" + ReportIncidentCu.TxtCamETimeTC3 + "', TxtCamSTimeH4='" + ReportIncidentCu.TxtCamSTimeH4 + "', TxtCamSTimeM4='" + ReportIncidentCu.TxtCamSTimeM4 + "', TxtCamSTimeTC4='" + ReportIncidentCu.TxtCamSTimeTC4 +
                "', TxtCamETimeH4='" + ReportIncidentCu.TxtCamETimeH4 + "', TxtCamETimeM4='" + ReportIncidentCu.TxtCamETimeM4 + "', TxtCamETimeTC4='" + ReportIncidentCu.TxtCamETimeTC4 + "', TxtCamSTimeH5='" + ReportIncidentCu.TxtCamSTimeH5 + "', TxtCamSTimeM5='" + ReportIncidentCu.TxtCamSTimeM5 + "', TxtCamSTimeTC5='" + ReportIncidentCu.TxtCamSTimeTC5 +
                "', TxtCamETimeH5='" + ReportIncidentCu.TxtCamETimeH5 + "', TxtCamETimeM5='" + ReportIncidentCu.TxtCamETimeM5 + "', TxtCamETimeTC5='" + ReportIncidentCu.TxtCamETimeTC5 + "', TxtCamSTimeH6='" + ReportIncidentCu.TxtCamSTimeH6 + "', TxtCamSTimeM6='" + ReportIncidentCu.TxtCamSTimeM6 + "', TxtCamSTimeTC6='" + ReportIncidentCu.TxtCamSTimeTC6 +
                "', TxtCamETimeH6='" + ReportIncidentCu.TxtCamETimeH6 + "', TxtCamETimeM6='" + ReportIncidentCu.TxtCamETimeM6 + "', TxtCamETimeTC6='" + ReportIncidentCu.TxtCamETimeTC6 + "', TxtCamSTimeH7='" + ReportIncidentCu.TxtCamSTimeH7 + "', TxtCamSTimeM7='" + ReportIncidentCu.TxtCamSTimeM7 + "', TxtCamSTimeTC7='" + ReportIncidentCu.TxtCamSTimeTC7 +
                "', TxtCamETimeH7='" + ReportIncidentCu.TxtCamETimeH7 + "', TxtCamETimeM7='" + ReportIncidentCu.TxtCamETimeM7 + "', TxtCamETimeTC7='" + ReportIncidentCu.TxtCamETimeTC7 + "', TxtTimeH='" + ReportIncidentCu.TxtTimeH + "', TxtTimeM='" + ReportIncidentCu.TxtTimeM + "', TxtTimeTC='" + ReportIncidentCu.TxtTimeTC + "', PlayerId1='" + ReportIncidentCu.PlayerId1 +
                "', PlayerId2='" + ReportIncidentCu.PlayerId2 + "', PlayerId3='" + ReportIncidentCu.PlayerId3 + "', PlayerId4='" + ReportIncidentCu.PlayerId4 + "', PlayerId5='" + ReportIncidentCu.PlayerId5 + "', Alias1='" + ReportIncidentCu.Alias1 + "', Alias2='" + ReportIncidentCu.Alias2 + "', Alias3='" + ReportIncidentCu.Alias3 + "', Alias4='" + ReportIncidentCu.Alias4 +
                "', Alias5='" + ReportIncidentCu.Alias5 + "', MemberSince1='" + ReportIncidentCu.MemberSince1 + "', MemberSince2='" + ReportIncidentCu.MemberSince2 + "', MemberSince3='" + ReportIncidentCu.MemberSince3 + "', MemberSince4='" + ReportIncidentCu.MemberSince4 + "', MemberSince5='" + ReportIncidentCu.MemberSince5 + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("MR Duty Managers") && Version.ToString() == "1") // MR Duty Managers Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', Supervisors='" + ReportDutyManagerMr.Sup + "', Whs='" + ReportDutyManagerMr.Whs + "', CostSavings='" + ReportDutyManagerMr.Cost + "', ClubPresent='" + ReportDutyManagerMr.ClubPres + "'," +
                " ClubMaintenance='" + ReportDutyManagerMr.ClubMain + "', Absenteeism='" + ReportDutyManagerMr.Absent + "', StaffIssues='" + ReportDutyManagerMr.StaffIssues + "', Gaming='" + ReportDutyManagerMr.Gaming + "', KeySecurity='" + ReportDutyManagerMr.KeySec + "'," +
                " Cameras='" + ReportDutyManagerMr.Cameras + "', GeneralComments='" + ReportDutyManagerMr.GenComm + "', LuckyRewards='" + ReportDutyManagerMr.LuckyRewards + "', Compliance='" + ReportDutyManagerMr.Compliance + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("MR Duty Managers") && Version.ToString() == "2") // MR Duty Managers Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', Supervisors='" + ReportDutyManagerMr.Sup + "', Whs='" + ReportDutyManagerMr.Whs + "', CostSavings='" + ReportDutyManagerMr.Cost + "', ClubPresent='" + ReportDutyManagerMr.ClubPres + "'," +
                " ClubMaintenance='" + ReportDutyManagerMr.ClubMain + "', Absenteeism='" + ReportDutyManagerMr.Absent + "', StaffIssues='" + ReportDutyManagerMr.StaffIssues + "', Gaming='" + ReportDutyManagerMr.Gaming + "', KeySecurity='" + ReportDutyManagerMr.KeySec + "', Cameras='" + ReportDutyManagerMr.Cameras +
                "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("CU Duty Managers") && Version.ToString() == "1") // UM Duty Managers Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', Supervisors='" + ReportDutyManagerCu.Sup + "', Whs='" + ReportDutyManagerCu.Whs + "', CostSavings='" + ReportDutyManagerCu.Cost + "', ClubPresent='" + ReportDutyManagerCu.ClubPres + "'," +
                " ClubMaintenance='" + ReportDutyManagerCu.ClubMain + "', Absenteeism='" + ReportDutyManagerCu.Absent + "', StaffIssues='" + ReportDutyManagerCu.StaffIssues + "', Gaming='" + ReportDutyManagerCu.Gaming + "', KeySecurity='" + ReportDutyManagerCu.KeySec + "'," +
                " Cameras='" + ReportDutyManagerCu.Cameras + "', GeneralComments='" + ReportDutyManagerCu.GenComm + "', LuckyRewards='" + ReportDutyManagerCu.LuckyRewards + "', Compliance='" + ReportDutyManagerCu.Compliance + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("MR Supervisors") && Version.ToString() == "1") // MR Supervisors Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', SignInSlip='" + ReportSupervisorMr.SignInSlip + "', Reception='" + ReportSupervisorMr.Reception + "', Gaming='" + ReportSupervisorMr.Gaming + "', Bar='" + ReportSupervisorMr.Bar + "'," +
                " TABKeno='" + ReportSupervisorMr.TabKeno + "', HouseKeeping='" + ReportSupervisorMr.HouseKeeping + "', Bistro='" + ReportSupervisorMr.Bistro + "', FoodHygiene='" + ReportSupervisorMr.FoodHygiene + "', Events='" + ReportSupervisorMr.Events + "'," +
                " CustomerService='" + ReportSupervisorMr.CustomerService + "', GeneralComments='" + ReportSupervisorMr.GenComm + "', LuckyRewards='" + ReportSupervisorMr.LuckyRewards + "', RSA='" + ReportSupervisorMr.RSA + "', AMLCTF='" + ReportSupervisorMr.AMLCTF + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("MR Reception") && Version.ToString() == "1") // MR Reception Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', SignInSlip='" + ReportReceptionMr.SignIn + "', Refusals='" + ReportReceptionMr.Refusals + "', EventsField='" + ReportReceptionMr.Events + "', GeneralComments='" + ReportReceptionMr.GenComm + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("CU Reception") && Version.ToString() == "1") // UM Reception Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', SignInSlip='" + ReportReceptionCu.SignIn + "', Refusals='" + ReportReceptionCu.Refusals + "', EventsField='" + ReportReceptionCu.Events + "', GeneralComments='" + ReportReceptionCu.GenComm + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("MR Function Supervisor") && Version.ToString() == "1") // MR Reception Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', FunctionName='" + ReportFunctionSupervisorMr.FunctionName + "', NumberOfGuests='" + ReportFunctionSupervisorMr.NoOfGuests + "', Setup='" + ReportFunctionSupervisorMr.Setup + "', MenuFeedback='" + ReportFunctionSupervisorMr.MenuFeed + "', BarFeedback='" + ReportFunctionSupervisorMr.BarFeed + "', StaffIssues='" + ReportFunctionSupervisorMr.StaffIss
                + "', GeneralComments='" + ReportFunctionSupervisorMr.GenComm + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }

        if (Name.Equals("MR Reception Supervisor") && Version.ToString() == "1") // MR Reception Supervisor Version 1
        {
            updateQuery = "UPDATE " + Table + " SET ModifyDate=current_timestamp, ShiftId='" + ShiftId + "', ShiftDate=(CONVERT(DateTime,'" + ShiftDate + "',103)), ShiftDOW='" + ShiftDOW + "', SignInSlip='" + ReportReceptionSupervisorMr.SignIn + "', Refusals='" + ReportReceptionSupervisorMr.Refusals + "', EventsField='" + ReportReceptionSupervisorMr.Events + "', GeneralComments='" + ReportReceptionSupervisorMr.GenComm + "', LastChanged=" + UserCredentials.StaffId + " WHERE ReportId='" + Id + "' AND AuditVersion='" + AuditVersion + "'";
        }
        return updateQuery;
    }

    public static bool RunEditMode // tells whether or not to run the editButton() in Default.aspx
    {
        get
        {
            if (HttpContext.Current.Session["RRunEditMode"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RRunEditMode"];
            }
        }
        set
        {
            HttpContext.Current.Session["RRunEditMode"] = value;
        }
    }

    public static bool PopulateFields // checks if program has to run ReadFiles method, should only run one time (Run like an initial Post Back) - Edit Mode
    {
        get
        {
            if (HttpContext.Current.Session["RPopulateFields"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RPopulateFields"];
            }
        }
        set
        {
            HttpContext.Current.Session["RPopulateFields"] = value;
        }
    }

    public static string SelectedStaffId // staff ID selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RSelectedStaffId"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RSelectedStaffId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSelectedStaffId"] = value;
        }
    }

    public static string SelectedStaffName // staff name selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RSelectedStaffName"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSelectedStaffName"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSelectedStaffName"] = value;
        }
    }

    public static string Id // report ID selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RId"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RId"] = value;
        }
    }

    public static string Name // report name selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RName"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RName"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RName"] = value;
        }
    }

    public static string Status // report status selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RStatus"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RStatus"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RStatus"] = value;
        }
    }

    public static string EntryDate // entry date the user has entered the report
    {
        get
        {
            if (HttpContext.Current.Session["REntryDate"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["REntryDate"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["REntryDate"] = value;
        }
    }

    public static string ShiftId // selected shift id of the selected report in the GridView List or updated report
    {
        get
        {
            if (HttpContext.Current.Session["RShiftId"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RShiftId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RShiftId"] = value;
        }
    }

    public static string ShiftDate // selected shift date of the selected report in the GridView List or updated report
    {
        get
        {
            if (HttpContext.Current.Session["RShiftDate"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RShiftDate"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RShiftDate"] = value;
        }
    }

    public static string ShiftDOW // shift DOW of the selected report in the GridView List or updated report
    {
        get
        {
            if (HttpContext.Current.Session["RShiftDOW"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RShiftDOW"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RShiftDOW"] = value;
        }
    }

    public static string Table // report table name selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RTable"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RTable"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RTable"] = value;
        }
    }

    public static string LinkedTable // linked report table name selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RLinkedTable"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RLinkedTable"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RLinkedTable"] = value;
        }
    }

    public static string Version // report version selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RVersion"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RVersion"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RVersion"] = value;
        }
    }

    public static string AuditVersion // report audit version selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RAuditVersion"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RAuditVersion"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RAuditVersion"] = value;
        }
    }

    public static string RowNumber // row number of the report selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RRowNumber"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRowNumber"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RRowNumber"] = value;
        }
    }

    public static bool ChangeRowNumber // once read by or manager sign is selected, check the row number for Previous and Next Report button
    {
        get
        {
            if (HttpContext.Current.Session["RChangeRowNumber"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RChangeRowNumber"];
            }
        }
        set
        {
            HttpContext.Current.Session["RChangeRowNumber"] = value;
        }
    }


    public static string ActiveReport // active report selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RActiveReport"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RActiveReport"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RActiveReport"] = value;
        }
    }

    public static string LinkedReport // linked report selected from the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RLinkedReport"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RLinkedReport"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RLinkedReport"] = value;
        }
    }

    public static string SelectQuery // active select query populated in the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RSelectQuery"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSelectQuery"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSelectQuery"] = value;
        }
    }

    public static string DefaultSelectQuery // default select query populated in the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RDefaultSelectQuery"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDefaultSelectQuery"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RDefaultSelectQuery"] = value;
        }
    }

    public static string LinkSelectQuery // active link select query populated in the gridview list
    {
        get
        {
            if (HttpContext.Current.Session["RLinkSelectQuery"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RLinkSelectQuery"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RLinkSelectQuery"] = value;
        }
    }

    public static string CurrentNavigationTab // active tab selected in the navigation
    {
        get
        {
            if (HttpContext.Current.Session["RCurrentNavigationTab"] == null)
            {
                return "1";
            }
            else
            {
                return HttpContext.Current.Session["RCurrentNavigationTab"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RCurrentNavigationTab"] = value;
        }
    }

    public static string ManagerSignQuery() // list of reports that needs manager sign-off
    {
        string keepSite;

        if (UserCredentials.Groups.Contains("MRReportsOperations") && UserCredentials.Groups.Contains("CUReportsClubManager"))
        {
            keepSite = "";
        }
        else if (UserCredentials.Groups.Contains("CUReportsClubManager"))
        {
            keepSite = " AND ReportName NOT LIKE '%MR%'"; // only show Club Umina Reports
        }
        else if (UserCredentials.Groups.Contains("MRReportsOperations"))
        {
            keepSite = " AND ReportName NOT LIKE '%CU%' or ([StaffId] = '" + ClubManagerUmina + "' and ReportStat LIKE '%Manager%')"; // only show Merrylands RSL Club Reports plus reports of the Club Manager of Club Umina
        }
        else
        {
            keepSite = "";
        }

        string managerSign = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table]," +
        " [Report_Version], [ReportStat], [AuditVersion], ROW_NUMBER() OVER (ORDER BY [ShiftDate] DESC, [ShiftId] DESC) AS [RowNum]" +
        " FROM [View_Reports] WHERE ReportName IN('" + UserCredentials.GroupsQuery + "') AND ReportStat LIKE '%Manager%' AND" +
        " [StaffId] != '" + UserCredentials.StaffId + "'" + keepSite;

        return managerSign;
    }

    public static bool ManagerSignOffRequired // check if report needs a manager sign off
    {
        get
        {
            if (HttpContext.Current.Session["RManagerSignOffRequired"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RManagerSignOffRequired"];
            }
        }
        set
        {
            HttpContext.Current.Session["RManagerSignOffRequired"] = value;
        }
    }


    public static bool HasReport // used for previous and next report selected
    {
        get
        {
            if (HttpContext.Current.Session["RHasReport"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasReport"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasReport"] = value;
        }
    }

    public static string ErrorMessage // error message for Incident Report
    {
        get
        {
            if (HttpContext.Current.Session["RErrorMessage"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RErrorMessage"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RErrorMessage"] = value;
        }
    }

    public static bool HasMember // member number found in the database
    {
        get
        {
            if (HttpContext.Current.Session["RHasMember"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasMember"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasMember"] = value;
        }
    }

    public static string MemberNumberChanged // member number text changed for Incident Report
    {
        get
        {
            if (HttpContext.Current.Session["RMemberNumberChanged"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RMemberNumberChanged"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RMemberNumberChanged"] = value;
        }
    }

    public static string LastReportId // last report Id in the database - used in creating a new Incident report
    {
        get
        {
            if (HttpContext.Current.Session["RLastReportId"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RLastReportId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RLastReportId"] = value;
        }
    }

    public static string Sort // used to hold the value to either sort the gridview to ascending or descending
    {
        get
        {
            if (HttpContext.Current.Session["RSort"] == null)
            {
                return "Set";
            }
            else
            {
                return HttpContext.Current.Session["RSort"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSort"] = value;
        }
    }

    public static string SortExpression // used to hold the column value expression that will be sorted
    {
        get
        {
            if (HttpContext.Current.Session["RSortExpression"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RSortExpression"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSortExpression"] = value;
        }
    }

    public static string SortExpressionPrevious // used to hold the column value expression that has been sorted
    {
        get
        {
            if (HttpContext.Current.Session["RSortExpressionPrevious"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RSortExpressionPrevious"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSortExpressionPrevious"] = value;
        }
    }

    public static string SortDirection // used to hold the value of either Ascending or Descending
    {
        get
        {
            if (HttpContext.Current.Session["RSortDirection"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RSortDirection"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSortDirection"] = value;
        }
    }

    public static string SortDirectionPrevious // used to hold the value of the previous sort selected
    {
        get
        {
            if (HttpContext.Current.Session["RSortDirectionPrevious"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RSortDirectionPrevious"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSortDirectionPrevious"] = value;
        }
    }

    public static void SortReset()
    {
        SortDirection = "";     // reset sort direction used in NextReport(), PreviousReport(), and OnSorting of GridView List
        SortDirectionPrevious = "";
        SortExpression = "";    // reset sort expression used in NextReport(), PreviousReport(), and OnSorting of GridView List
        SortExpressionPrevious = "";
        Sort = "Set";           // reset sort variable to it's default nature
    }

    public static string ReadList // used to hold the value of the users who read the report selected
    {
        get
        {
            if (HttpContext.Current.Session["RReadList"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RReadList"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RReadList"] = value;
        }
    }

    public static string ReadListStaffId // used to hold the value of the staff ids who read the report selected
    {
        get
        {
            if (HttpContext.Current.Session["RReadListStaffId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RReadListStaffId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RReadListStaffId"] = value;
        }
    }

    public static string Comment // used to hold the value of entered comment to be entered in the report selected
    {
        get
        {
            if (HttpContext.Current.Session["RComment"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RComment"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RComment"] = value;
        }
    }

    public static bool HasManagerSign // checks if there is any manager signature in the selected report
    {
        get
        {
            if (HttpContext.Current.Session["RHasManagerSign"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasManagerSign"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasManagerSign"] = value;
        }
    }

    public static string ManagerSignId // used to hold the value of manager's staff id who signed the selected report
    {
        get
        {
            if (HttpContext.Current.Session["RManagerSignId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RManagerSignId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RManagerSignId"] = value;
        }
    }

    public static bool HasPendingAction // checks if there is still pending actions waiting
    {
        get
        {
            if (HttpContext.Current.Session["RHasPendingAction"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasPendingAction"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasPendingAction"] = value;
        }
    }

    public static bool HasUserSign // checks if there is already a user signature in the selected report
    {
        get
        {
            if (HttpContext.Current.Session["RHasUserSign"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasUserSign"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasUserSign"] = value;
        }
    }

    // checks whether there were changes made
    public static bool HasChange
    {
        get
        {
            if (HttpContext.Current.Session["RHasChange"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasChange"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasChange"] = value;
        }
    }

    // tells where the changes where made
    public static string WhereChangeHappened
    {
        get
        {
            if (HttpContext.Current.Session["RWhereChangeHappened"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RWhereChangeHappened"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RWhereChangeHappened"] = value;
        }
    }

    // chaekcs whether there were changes made in the image
    public static bool HasImageChange
    {
        get
        {
            if (HttpContext.Current.Session["HasImageChanged"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RImageChanged"];
            }
        }
        set
        {
            HttpContext.Current.Session["RImageChanged"] = value;
        }
    }

    public static bool HasErrorMessage // checks if there is error message to display
    {
        get
        {
            if (HttpContext.Current.Session["RHasErrorMessage"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasErrorMessage"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasErrorMessage"] = value;
        }
    }

    public static bool HasErrorMessage1 // checks if there is an error message to display (before signing report)
    {
        get
        {
            if (HttpContext.Current.Session["RHasErrorMessage1"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RHasErrorMessage1"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasErrorMessage1"] = value;
        }
    }

    public static string SelectedAcp
    {
        get
        {
            if (HttpContext.Current.Session["RSelectedAcpPerson"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RSelectedAcpPerson"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RSelectedAcpPerson"] = value;
        }
    }

    public static string LinkSort // used to hold the value to either sort the linked gridview to ascending or descending
    {
        get
        {
            if (HttpContext.Current.Session["RLinkSort"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RLinkSort"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RLinkSort"] = value;
        }
    }

    public static string LinkSortDirection // used to hold the value of link report sort either Ascending or Descending
    {
        get
        {
            if (HttpContext.Current.Session["RLinkSortDirection"] == null)
            {
                return "Set";
            }
            else
            {
                return HttpContext.Current.Session["RLinkSortDirection"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RLinkSortDirection"] = value;
        }
    }

    public static string PageSize // used to hold the value of the size of the page
    {
        get
        {
            if (HttpContext.Current.Session["RPageSize"] == null)
            {
                return "10";
            }
            else
            {
                return HttpContext.Current.Session["RPageSize"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RPageSize"] = value;
        }
    }

    public static int HasDisplayedUnsignedReport // used to hold to check if program have already displayed an alert message to user for any existing Awaiting Completion reports to be signed
    {
        get
        {
            if (HttpContext.Current.Session["RHasDisplayedUnsignedReport"] == null)
            {
                return 0;
            }
            else
            {
                return (int)HttpContext.Current.Session["RHasDisplayedUnsignedReport"];
            }
        }
        set
        {
            HttpContext.Current.Session["RHasDisplayedUnsignedReport"] = value;
        }
    }

    public static string ClubManagerUmina
    {
        get
        {
            if (HttpContext.Current.Session["RClubManagerUmina"] == null)
            {
                return "1";
            }
            else
            {
                return HttpContext.Current.Session["RClubManagerUmina"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RClubManagerUmina"] = value;
        }
    }

    public static bool WrongUsername // checks if username entered in the comment section is wrong
    {
        get
        {
            if (HttpContext.Current.Session["RWrongUsername"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["RWrongUsername"];
            }
        }
        set
        {
            HttpContext.Current.Session["RWrongUsername"] = value;
        }
    }
}