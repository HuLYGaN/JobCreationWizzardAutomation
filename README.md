# Job creation wizard automation project

##Description

Job Creation Wizard Automation ReadMe V1.0

Tests

Tests are located in Job Creation Wizzard Tests Project in corresponding files.  Each of files represents tests for different pages, except “JobCreationWizzardTest“, which serves as base test.
Tests are run via NUnit.


JobCreationWizzardTest :

Serves as Initialization for all other tests. It logs in user and starts creation of a job.


HomePageTests :

User_Is_At_Login_Page() – asserts whether user is successfully logged in from home page. 


LoginTests :

User_Can_Login() – asserts whether user is logged to dashboard page.


DashboardTests :

User_Can_Click_Add_New_Job() – asserts whether user after clicking 'Add new job' is displayed with new job page-


NewJobTests :

Proceed_Job_Basic_No_Input() – asserts validation of fields in case when they are not populated

Proceed_Job_Basic_No_Job_Description() – asserts validation when only description field is not pouplated

Proceed_Job_Basic_No_Job_Title() – asserts validation when job title is not populated

Proceed_Job_Basic_Populate_All() – asserts successful population of all fields


NewJobTestsDetails :


Proceed_Job_Details_No_Input()
Proceed_Job_Details_Start_Date_String_Input()
Proceed_Job_Details_All()

	
 – tests assert validation on all fields. User can manipulate with tests by changing values in test via commands which correspond to names from web page.
NOTE: There could be a bug here , since user is able to populate in start date numbers (in.eg. „12345“) and to proceed. Also, user can manually add date in past when not using date selector.


NewJobTestsSkills :

Proceed_Job_Skills_Validation()
Correct_Position_Job_Skills_Validation()
Proceed_One_Language_Skill_Expert()
Proceed_To_Confirmation()

– tests assert validation on all fields. User can manipulate with tests by changing values in test via commands which correspond to names from web page.


NewJobTestsConfirmation :

ScheduleACall()
Schedule_With_One_Confirmation()
Schedule_With_All_Confirmation()

-	tests validate whether user has clicked all confirmations or only one or two. User can manipulate with this values from tests by setting true/false.


NewJobTestsTechCall :

Jump_to_Job()
-test finishes creation of job, and validates whether user has landed to Jobs page.


Technologies used:

Selenium WebDriver / Firefox driver with C#
NUnit


