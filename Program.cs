using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAIScraper
{
    class Program
    {

        private static string endpoint = "https://api.collegeai.com/v1/api/college/info?api_key=zPrUOEVtV86G&info_ids=TOEFLRequirement%2CacceptanceRate%2CacceptedDist%2CactCumulativePercentile25%2CactCumulativePercentile75%2CactEnglishPercentile25%2CactEnglishPercentile75%2CactMathPercentile25%2CactMathPercentile75%2CactSciencePercentile25%2CactSciencePercentile75%2CactWritingPercentile25%2CactWritingPercentile75%2Caddr%2CadmissionTestScores%2CadmissionsWebsite%2Caliases%2CanyAlternativeTuitionPlansOfferedByInstitution%2CapplicationWebsite%2CappliedDist%2CaverageAgeOfEntry%2CaverageNetCost%2CavgCostOfAttendance%2CavgNetPrice%2CcalendarSystem%2CcampusImage%2Ccity%2CclassSizeRange10To19%2CclassSizeRange20To29%2CclassSizeRange2To9%2CclassSizeRange30To39%2CclassSizeRange40To49%2CclassSizeRange50To99%2CclassSizeRangeOver100%2Ccollegesthatchangelivesfourthedition%2Ccolors%2CcompletionOfCollegePreparatoryProgram%2Cdemographics2mor%2CdemographicsAian%2CdemographicsAsian%2CdemographicsAvgFamilyIncome%2CdemographicsBlack%2CdemographicsHisp%2CdemographicsMedianFamilyIncome%2CdemographicsMedianHouseholdIncome%2CdemographicsMen%2CdemographicsNhpi%2CdemographicsNra%2CdemographicsUnkn%2CdemographicsWhite%2CdemographicsWomen%2CdescriptionCitation%2CentryProb%2CfederalLoanRate%2CfinancialAidWebsite%2CformalDemonstrationOfCompetencies%2CfraternitiesPercentParticipation%2CfreshmenRequiredToLiveOnCampus%2CgraduationRate%2ChsGPARequirement%2ChsRankRequirement%2CinStateTuition%2CisPrivate%2CloanPrincipal%2ClocaleClass%2ClocaleSize%2ClocationLat%2ClocationLong%2ClongDescription%2CmajorGraduates%2CmedianEarningsSixYrsAfterEntry%2CmedianEarningsTenYrsAfterEntry%2CmenAdmitted%2CmenApplicants%2CmenEnrolled%2CmenOnly%2Cname%2CnetPriceByIncomeLevel%2CnetPriceByIncomeLevel0To3000%2CnetPriceByIncomeLevel110001Plus%2CnetPriceByIncomeLevel30001To48000%2CnetPriceByIncomeLevel48001To75000%2CnetPriceByIncomeLevel75001To110000%2CnetPriceWebsite%2CnumberOfFullTimeFaculty%2CnumberOfPartTimeFaculty%2ConCampusHousingAvailable%2CotherAlternativeTuitionPlan%2CotherTest%2CoutOfStateTuition%2CpercentFemale%2CpercentFirstGeneration%2CpercentMale%2CpercentOfStudentsWhoReceiveFinancialAid%2CpercentStudentsReceivingFederalGrantAid%2CprepaidTuitionPlan%2CprimaryFaith%2CrankingsBestCatholicColleges%2CrankingsBestCollegeAcademics%2CrankingsBestCollegeAthletics%2CrankingsBestCollegeCampuses%2CrankingsBestCollegeFood%2CrankingsBestCollegeLocations%2CrankingsBestCollegeProfessors%2CrankingsBestColleges%2CrankingsBestCollegesForArt%2CrankingsBestCollegesForBiology%2CrankingsBestCollegesForBusiness%2CrankingsBestCollegesForChemistry%2CrankingsBestCollegesForCommunications%2CrankingsBestCollegesForComputerScience%2CrankingsBestCollegesForDesign%2CrankingsBestCollegesForEconomics%2CrankingsBestCollegesForEngineering%2CrankingsBestCollegesForHistory%2CrankingsBestCollegesForNursing%2CrankingsBestCollegesForPhysics%2CrankingsBestGreekLifeColleges%2CrankingsBestStudentAthletes%2CrankingsBestStudentLife%2CrankingsBestTestOptionalColleges%2CrankingsBestValueColleges%2CrankingsCollegesThatAcceptTheCommonApp%2CrankingsCollegesWithNoApplicationFee%2CrankingsHardestToGetIn%2CrankingsHottestGuys%2CrankingsMostConservativeColleges%2CrankingsMostDiverseColleges%2CrankingsMostLiberalColleges%2CrankingsTopPartySchools%2CrankingsTopPrivate%2Crecommendations%2Cregion%2CreligiousAffiliation%2CrotcAirforceOffered%2CrotcArmyOffered%2CrotcNavyOffered%2CrotcOffered%2CsatMathPercentile25%2CsatMathPercentile75%2CsatReadingPercentile25%2CsatReadingPercentile75%2CsecondarySchoolRecordRequirement%2CshortDescription%2CsororitiesPercentParticipation%2CstateAbbr%2CstateName%2CstudentFacultyRatio%2CstudentRightToKnowAthleteWebsite%2CstudentShareByIncomeLevel0To30000%2CstudentShareByIncomeLevel110001Plus%2CstudentShareByIncomeLevel30001To48000%2CstudentShareByIncomeLevel480001To75000%2CstudentShareByIncomeLevel75001To110000%2CstudentsSubmittingACT%2CstudentsSubmittingSAT%2Ctheprincetonreviewbest382colleges2018%2CtotalAdmitted%2CtotalApplicants%2CtotalEnrolled%2CtuitionGuaranteePlan%2CtuitionPaymentPlan%2CtypeYear%2CundergraduateSize%2CvetMilitaryServiceWebsite%2Cwebsite%2CwomenAdmitted%2CwomenApplicants%2CwomenEnrolled%2CwomenOnly%2Czipcode&college_unit_ids=";
        private static string mysql_host = "localhost";
        private static string mysql_user = "root";
        private static string mysql_pass = "Coverit2020!";
        private static string mysql_db = "collegeai";
        private static string mysql_id_tbl = "collegeid";
        private static string mysql_info_tbl = "infoid";
        private static string mysql_info_insert = "";
        private static string[] info_ids = {
            "TOEFLRequirement", "acceptanceRate", "acceptedDist", "actCumulativePercentile25", "actCumulativePercentile75", "actEnglishPercentile25", "actEnglishPercentile75", "actMathPercentile25", "actMathPercentile75", "actSciencePercentile25", "actSciencePercentile75", "actWritingPercentile25", "actWritingPercentile75", "addr", "admissionTestScores", "admissionsWebsite", "aliases", "anyAlternativeTuitionPlansOfferedByInstitution", "applicationWebsite", "appliedDist", "averageAgeOfEntry", "averageNetCost", "avgCostOfAttendance", "avgNetPrice", "calendarSystem", "campusImage", "city", "classSizeRange10To19", "classSizeRange20To29", "classSizeRange2To9", "classSizeRange30To39", "classSizeRange40To49", "classSizeRange50To99", "classSizeRangeOver100", "collegesthatchangelivesfourthedition", "colors", "completionOfCollegePreparatoryProgram", "demographics2mor", "demographicsAian", "demographicsAsian", "demographicsAvgFamilyIncome", "demographicsBlack", "demographicsHisp", "demographicsMedianFamilyIncome", "demographicsMedianHouseholdIncome", "demographicsMen", "demographicsNhpi", "demographicsNra", "demographicsUnkn", "demographicsWhite", "demographicsWomen", "descriptionCitation", "entryProb", "federalLoanRate", "financialAidWebsite", "formalDemonstrationOfCompetencies", "fraternitiesPercentParticipation", "freshmenRequiredToLiveOnCampus", "graduationRate", "hsGPARequirement", "hsRankRequirement", "inStateTuition", "isPrivate", "loanPrincipal", "localeClass", "localeSize", "locationLat", "locationLong", "longDescription", "majorGraduates", "medianEarningsSixYrsAfterEntry", "medianEarningsTenYrsAfterEntry", "menAdmitted", "menApplicants", "menEnrolled", "menOnly", "name", "netPriceByIncomeLevel", "netPriceByIncomeLevel0To3000", "netPriceByIncomeLevel110001Plus", "netPriceByIncomeLevel30001To48000", "netPriceByIncomeLevel48001To75000", "netPriceByIncomeLevel75001To110000", "netPriceWebsite", "numberOfFullTimeFaculty", "numberOfPartTimeFaculty", "onCampusHousingAvailable", "otherAlternativeTuitionPlan", "otherTest", "outOfStateTuition", "percentFemale", "percentFirstGeneration", "percentMale", "percentOfStudentsWhoReceiveFinancialAid", "percentStudentsReceivingFederalGrantAid", "prepaidTuitionPlan", "primaryFaith", "rankingsBestCatholicColleges", "rankingsBestCollegeAcademics", "rankingsBestCollegeAthletics", "rankingsBestCollegeCampuses", "rankingsBestCollegeFood", "rankingsBestCollegeLocations", "rankingsBestCollegeProfessors", "rankingsBestColleges", "rankingsBestCollegesForArt", "rankingsBestCollegesForBiology", "rankingsBestCollegesForBusiness", "rankingsBestCollegesForChemistry", "rankingsBestCollegesForCommunications", "rankingsBestCollegesForComputerScience", "rankingsBestCollegesForDesign", "rankingsBestCollegesForEconomics", "rankingsBestCollegesForEngineering", "rankingsBestCollegesForHistory", "rankingsBestCollegesForNursing", "rankingsBestCollegesForPhysics", "rankingsBestGreekLifeColleges", "rankingsBestStudentAthletes", "rankingsBestStudentLife", "rankingsBestTestOptionalColleges", "rankingsBestValueColleges", "rankingsCollegesThatAcceptTheCommonApp", "rankingsCollegesWithNoApplicationFee", "rankingsHardestToGetIn", "rankingsHottestGuys", "rankingsMostConservativeColleges", "rankingsMostDiverseColleges", "rankingsMostLiberalColleges", "rankingsTopPartySchools", "rankingsTopPrivate", "recommendations", "region", "religiousAffiliation", "rotcAirforceOffered", "rotcArmyOffered", "rotcNavyOffered", "rotcOffered", "satMathPercentile25", "satMathPercentile75", "satReadingPercentile25", "satReadingPercentile75", "secondarySchoolRecordRequirement", "shortDescription", "sororitiesPercentParticipation", "stateAbbr", "stateName", "studentFacultyRatio", "studentRightToKnowAthleteWebsite", "studentShareByIncomeLevel0To30000", "studentShareByIncomeLevel110001Plus", "studentShareByIncomeLevel30001To48000", "studentShareByIncomeLevel480001To75000", "studentShareByIncomeLevel75001To110000", "studentsSubmittingACT", "studentsSubmittingSAT", "theprincetonreviewbest382colleges2018", "totalAdmitted", "totalApplicants", "totalEnrolled", "tuitionGuaranteePlan", "tuitionPaymentPlan", "typeYear", "undergraduateSize", "vetMilitaryServiceWebsite", "website", "womenAdmitted", "womenApplicants", "womenEnrolled", "womenOnly", "zipcode"
        };

        static void Main(string[] args)
        {
            try
            {
                mysql_info_insert = "INSERT INTO " + mysql_info_tbl + " (unit_id";
                foreach(string info_id in info_ids)
                {
                    mysql_info_insert += ", " + info_id;
                }
                mysql_info_insert += ") VALUES (@unit_id";
                foreach (string info_id in info_ids)
                {
                    mysql_info_insert += ", @" + info_id;
                }
                mysql_info_insert += ")";

                using (var connection = new MySqlConnection("Server=" + mysql_host + ";User ID=" + mysql_user + ";Password=" + mysql_pass + ";Database=" + mysql_db))
                {
                    connection.Open();

                    List<int> college_ids = new List<int>();
                    List<string> college_names = new List<string>();

                    using (var idCommand = new MySqlCommand("SELECT college_name, unit_id FROM " + mysql_id_tbl + ";", connection))
                    {
                        using (var idReader = idCommand.ExecuteReader())
                        {
                            while (idReader.Read())
                            {
                                college_names.Add(idReader.GetString(0));
                                college_ids.Add(idReader.GetInt32(1));
                            }
                        }
                    }

                    for(int i = 0; i < college_ids.Count; i ++)
                    {
                        Console.WriteLine(String.Format("\n{0} / {1} : {2}", i + 1, college_ids.Count, college_names[i]));

                        var httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
                        httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                        HttpResponseMessage response = httpClient.GetAsync(endpoint + college_ids[i]).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string content = response.Content.ReadAsStringAsync().Result;
                            object resp = JsonConvert.DeserializeObject(content);
                            if (resp is JObject respObj)
                            {
                                string success = respObj["success"].ToString();
                                if (success != "True")
                                {
                                    Console.WriteLine(respObj["message"].ToString());
                                    continue;
                                }
                                foreach (JObject college in (JArray) respObj["colleges"])
                                {
                                    using (var insertCommand = new MySqlCommand(mysql_info_insert, connection))
                                    {
                                        foreach(string info_id in info_ids)
                                        {
                                            if(college.ContainsKey(info_id))
                                                insertCommand.Parameters.AddWithValue(info_id, college[info_id].ToString());
                                            else
                                                insertCommand.Parameters.AddWithValue(info_id, null);
                                        }
                                        insertCommand.Parameters.AddWithValue("unit_id", college_ids[i]);
                                        insertCommand.ExecuteNonQuery();
                                    }
                                    Console.WriteLine("1 College Added");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
