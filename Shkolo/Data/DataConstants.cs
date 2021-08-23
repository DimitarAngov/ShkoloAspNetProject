namespace Shkolo.Data
{
    public class DataConstants
    {
        public const int NumInClassMin = 1;
        public const int NumInClassMax = 30;

        public const int TermNumberMin = 1;
        public const int TermNumberMax = 2;

        public const int NameMaxLength = 50;
        public const int PhoneNumberMinLength = 13;
        public const int PhoneNumberMaxLength = 15;
        public const int EmailMaxLength = 30;
        public const int AdressMaxLength = 100;

        public const int TypeGradeIdMin = 1;
        public const int TypeGradeIdMax = 20;

        public const int TypeAbsenceIdMin = 1;
        public const int TypeAbsenceIdMax = 10;

        public const int TypeAbsenceReasonIdMin = 1;
        public const int TypeAbsenceReasonIdMax = 10;

        public const int DateMin = 10;
        public const int DateMax = 10;
        public class Diary
        {
            public const int DiaryClassNameMaxLength = 1;
            public const int DiaryClassNumberMin = 1;
            public const int DiaryClassNumberMax = 12;
            public const int DiaryIdMin = 1;
            public const int DiaryIdMax = 50;
            public const int DiaryParentIdMin = 1;
            public const int DiaryParentIdMax = 100;
            public const int DiaryDoctorIdMin = 1;
            public const int DiaryDoctorIdMax = 100;
        }

        public class Grade
        {
            public const int GradeStudentsMaxLength = 4;
            public const int GradeDescriptionMaxLength = 100;
        }

        public class Schedule
        {
            public const int ScheduleDayOfWeekMin = 1;
            public const int ScheduleDayOfWeekMax = 5;
            public const int ScheduleSchoolHourMin = 1;
            public const int ScheduleSchoolHourMax = 11;
        }

        public class Student
        {
            public const int StudentDateOfBirthMin = 10;
            public const int StudentPlaceOfBirthMax = 20;
            public const int StudentIdMin = 1;
            public const int StudentIdMax = 2000;
            public const int StudentPageNum = 10;
            public const int StudentOrderToLeave = 30;
            public const int StudentOrderToEnroll = 20;
            public const int StudentMinLength = 1;
            public const int StudentMaxLength = 2;
        }

        public class ScheduleHour
        {
            public const int ScheduleHourTopicsMaxLength = 1000;
            public const int StudentPlaceOfBirthMax = 20;
        }

        public class TypeGrade
        {
            public const int TypeGradeNameMaxLength = 25;
        }

        public class TypeSubject
        {
            public const int TypeSubjectNameMaxLength = 10;
        }

        public class TypeAbsence
        {
            public const int TypeAbsenceNameMaxLength = 12;
        }
    }
}
