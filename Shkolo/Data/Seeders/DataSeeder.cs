﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shkolo.Data.Seeders
{
    public class DataSeeder
    {
        public string[] DataDiary =
          {
                "ЗПГ","9","Е","Костадин Стефанов Митрев","2021",
                "ЗПГ","8","Е","Величка Георгиева Божинова","2021"
          };
        public string[] DataSubjects =
          {
                    "Български език и литература",
                    "Английски език",
                    "Френски език",
                    "Математика",
                    "Информационни технологии",
                    "История и цивилизации",
                    "География и икономика",
                    "Философия",
                    "Биология и здравно образование",
                    "Физика и астрономия",
                    "Химия и опазване на околната среда",
                    "Физическо възпитание и спорт",
                    "Здравословни и безопасни условия на труд",
                    "Материалознание",
                    "Техническа механика",
                    "Основи на мехатрониката",
                    "Основи на хидравлични и пневматични устройства",
                    "Теория на двигатели с вътрешно горене",
                    "Учебна практика - по специалността",
                    "Спортни дейности (бадминтон)",
                    "Безопасност на движението",
                    "Час на класа"
        };

        public string[] DataTeachers =
        {
                    "Катя Иванова Петкова",
                    "Мария Василева Якимова-Кацарска",
                    "Мариам Таквор Гилигян-Зарарева",
                    "Сашка Андонова Николова",
                    "Елза Василева Булакиева",
                    "Красимира Любенова Пановска",
                    "Невена Иванова Шингарова-Кажова",
                    "Катя Методиева Дукова",
                    "Мая Димитрова Илиева",
                    "Костадин Стефанов Митрев",
                   "Снежана Николова Маламова",
                    "Роза Атанасова Иванова",
                    "Анелия Стоянова Калъмбова",
                    "Емил Иванов Терзийски",
                    "Снежанка Христова Кацарова",
                    "Божидар Георгиев Цулев",
                   "Александър Методиев Дерибанов",
                   "Ботьо Димитров Пенев",
                   "Мариана Александрова Ризова",
                   "Иван Костадинов Попов",
                   "Благовест Георгиев Илиев",
                   "Стефани Николаева Мездрова-Кирова",
                   "Харалампи Иванов Иванов",
                   "Мария Илиева Кацарова",
                   "Петранка Захариева Михайлова",
                   "Величка Георгиева Божинова",
                   "Валентина Димитрова Мутафчиева",
                   "Димитринка Любенова Мешкова",
         };

        public string[] DataTypeSubjects =
        {
                    "ООП",
                    "ОбПП",
                    "ИУЧ - ОтПП",
                    "ИУЧ - РПП",
                    "…"
        };

        public string[] DataTypeAbsences =
        {
                    "Уважително",
                    "Неуважително",
                    "Закъснение",
                    ""
        };

        public string[] DataTypeAbsencesReason =
        {
                    "Здравословни",
                    "Семейни",
                    "Други",
                    ""
        };

        public string[] DataTypeGrade =
        {
                    "Устно изпитване",
                    "Писмено изпитване",
                    "Практическо изпитване",
                    "Тест",
                    "Активно участие",
                    "Самостоятелна работа",
                    "Домашна работа",
                    "Контролна работа",
                    "Класна работа",
                    "Входно равнище",
                    "Междинно равнище",
                    "Изходно равнище",
                    "Срочна",
                    "Годишна",
                    "От друго училище",
                    "От друга паралелка",
                    "Проект"
        };

        public string[] DataCourses = {
                    "Български език и литература","ООП","Катя Иванова Петкова",
                    "Английски език", "ООП", "Мария Василева Якимова-Кацарска",
                    "Френски език", "ООП", "Мариам Таквор Гилигян-Зарарева",
                    "Математика","ООП","Сашка Андонова Николова",
                    "Информационни технологии","ООП","Елза Василева Булакиева",
                    "Информационни технологии","ООП","Красимира Любенова Пановска",
                    "История и цивилизации","ООП","Невена Иванова Шингарова-Кажова",
                    "География и икономика","ООП","Катя Методиева Дукова",
                    "Философия","ООП","Роза Атанасова Иванова",
                    "Биология и здравно образование","ООП","Анелия Стоянова Калъмбова",
                    "Физика и астрономия","ООП","Емил Иванов Терзийски",
                    "Химия и опазване на околната среда","ООП","Мая Димитрова Илиева",
                    "Физическо възпитание и спорт","ООП","Костадин Стефанов Митрев",
                    "Здравословни и безопасни условия на труд","ОбПП","Снежана Николова Маламова",
                    "Материалознание","ИУЧ - ОтПП","Снежанка Христова Кацарова",
                    "Техническа механика","ИУЧ - ОтПП","Снежанка Христова Кацарова",
                    "Основи на мехатрониката","ИУЧ - РПП","Снежанка Христова Кацарова",
                    "Основи на хидравлични и пневматични устройства","ИУЧ - РПП","Снежанка Христова Кацарова",
                    "Теория на двигатели с вътрешно горене","ИУЧ - РПП","Снежанка Христова Кацарова",
                    "Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев",
                    "Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов",
                    "Спортни дейности (бадминтон)","…","Костадин Стефанов Митрев",
                    "Безопасност на движението","…","Александър Методиев Дерибанов",
                    "Български език и литература","ООП","Ботьо Димитров Пенев",
                    "Математика","ООП","Мариана Александрова Ризова",
                    "Математика","ООП","Иван Костадинов Попов",
                    "География и икономика","ООП","Благовест Георгиев Илиев",
                    "География и икономика","ООП","Стефани Николаева Мездрова-Кирова",
                    "Биология и здравно образование","ООП","Величка Георгиева Божинова",
                    "Физика и астрономия","ООП","Валентина Димитрова Мутафчиева",
                    "Философия","ООП","Харалампи Иванов Иванов",
                    "Философия","ООП","Мария Илиева Кацарова",
                    "Философия","ООП","Петранка Захариева Михайлова",
                    "Химия и опазване на околната среда","ООП","Димитринка Любенова Мешкова",
                    "Английски език", "ООП", "Мариам Таквор Гилигян-Зарарева",
                    "Час на класа","…","Костадин Стефанов Митрев"
        };

        public string[] DataStudents = {

                    "Асен Радославов Калоянов","2005-05-15","Сандански","Георги Сава Раковски No 7","+359892935556","1","Български език и литература","ООП","Катя Иванова Петкова","Стефка Асенова Калоянова","+359897279212","null","null","Димитър  Гогушев","0889391996/2","167/134","null","null",
                    "Асен Росенов Методиев","2004-10-05","Сандански"," ул.Извън регулация No 5","null","2","Български език и литература","ООП","Катя Иванова Петкова","Елена Стойчева Иванова","+359893893829","null","null","Маргарита  Ламбрева","+359887001958","147/160","null","null",
                    "Иван Кирилов Гоцев","2005-03-14","Сандански","ул.Илия Минев No 17","+359894460846","3","Български език и литература","ООП","Катя Иванова Петкова","Величка Иванова Гоцева","null","vilivvezarova88@gmail.com","null","Радослав  Чупетловски","+359889391200","169/137","null","null",
                    "Илия Горанов Аргиров","2005-10-03","Сандански"," ул.Рила No 13","+359894893517","4","Български език и литература","ООП","Катя Иванова Петкова","Росица  Аргирова","+359895104689","rosicaargirova44@gmail.com","null","Илиана  Харискова","+359887884709","169/138","null","null",
                    "Илиян Димитров Шуманов","2005-07-13","Сандански","null","+359877658504","5","Български език и литература","ООП","Катя Иванова Петкова","Димитър  Шуманов","+359884267090","null","null","Илиана  Харискова","+359887884709","169/139","null","null",
                    "Исмаел Антонов Асенов","2005-10-10","Сандански","ул.Извънрегулация Север No 16","+359892331726","6","Български език и литература","ООП","Катя Иванова Петкова","Антон  Асенов","+359896990384","null","null","д-р  Николова","+359887926650","169/140","null","null",
                    "Йордан Георгиев Шопов","2005-07-21","Сандански","ул.Радецки No 17","+359896115160","7","Български език и литература","ООП","Катя Иванова Петкова","Георги  Шопов","+359878984310","null","null","Доктор  Темелкова","+359888918778","169/141","null","null",
                    "Йордан Стойчев Ралков","2005-04-17","Сандански","ул.Свети Врач No 1","+359876392430","8","Български език и литература","ООП","Катя Иванова Петкова","Стойчо  Ралков","+359876158999","desi.ralkova@abv.bg","null","Доктор  Гогушев","+359889391996","169/143","null","null",
                    "Кирил Росенов Петров","2005-07-18","Сандански","бул.Свобода No 49","+359897599474","9","Български език и литература","ООП","Катя Иванова Петкова","Димитрина  Петрова","+359897401211","dimitrinacorocono@gmail.com","null","Д-Р Ивелина  Станоева","+359889510845","169/144","null","null",
                    "Любен Симеонов Стоянов","2005-03-24","Сандански"," ул.Славянка No 1","+359893715218","10","Български език и литература","ООП","Катя Иванова Петкова","Таня  Стоянова","+359879772502","null","null","Ваня  Мишева","+359887199924","169/145","null","null",
                    "Мартин Ризов Бакалов","2004-12-11","Сандански"," ул. Кукуш No 6","+359877745103","11","Български език и литература","ООП","Катя Иванова Петкова","Юлияна  Михайлова","null","null","null","Любен  Янков","+359888692420","147/161","null","null",
                    "Методи Димитров Митрев","2005-03-01","Сандански","ул.Кольо Фичето No 8","+359878317599","12","Български език и литература","ООП","Катя Иванова Петкова","Димитър  Митрев","+359876559905","null","null","Д- Р Явор  Павлов","+359898659032","169/146","null","null",
                    "Николай Атанасов Сребърнов","2005-06-05","Сандански","с.Склаве ул.Климент Охридски No 1","+359895852714","13","Български език и литература","ООП","Катя Иванова Петкова","Виолета  Сребърнова","+359898694323","srebarnovavioleta73@abv.bg","null","д-р  Георгиева","+359887981461","169/147","null","null",
                    "Николай Милчев Трайков","2006-02-04","Сандански","ул.Младост Nov15","+359892050435","14","Български език и литература","ООП","Катя Иванова Петкова","Красимира Алексиева Трайкова","+359877100503","null","null","Д- Р Явор  Павлов","+359898659032","173/9","null","null",
                    "Огнян Александров Огнянов","2005-01-08","Сандански","null","+359896005061","15","Български език и литература","ООП","Катя Иванова Петкова","Александър  Кирилов","+359892088009","null","null","Маргарита  Ламбрева","+359887001958","169/148","null","null",
                    "Рамона Ангелова Кочева","2005-05-22","Сандански","ул.Осогово No 2","+359892725596","16","Български език и литература","ООП","Катя Иванова Петкова","Филка  Славчева","+359893721228","null","null","Радослав  Чупетловски","+359889391200","169/149","null","null",
                    "Симеон Александров Александров","2005-01-30","Сандански","ул.Сердика No 3","+359896511818","17","Български език и литература","ООП","Катя Иванова Петкова","Александър  Александров","null","null","null","Д- Р Явор  Павлов","+359898659032","169/150","null","null",
                    "Стамен Станетков Пикянски","2006-05-10","Сандански","с.Чучулигово,общ.Петрич,България","+359877667423","18","Български език и литература","ООП","Катя Иванова Петкова","Силвия  Пикянска","+359876515736","Vanitami@abv.bg","null","д-р  Турнов","+359887255743","173/11","null","null",
                    "Юлияна Найчова Едипова","2004-09-17","Сандански"," ул.Стефан Караджа No 20","+359893739252","19","Български език и литература","ООП","Катя Иванова Петкова","Найчо  Едипов","null","null","null","Доктор  Темелкова","+359888918778","147/162","null","null",
                    "Пепа Стефанова Ангелова","2006-04-21","Харманли","ул.Козма и Дамян № 12","+359897348227","20","Български език и литература","ООП","Катя Иванова Петкова","Стоянка Иванова Ангелова","+359894249089","null","с. Троян","Антония  Желева","+359888894400","null","null","null"
        };

        public string[] DataSchedules = {

                     "1","1","null","null","История и цивилизации","ООП","Невена Иванова Шингарова-Кажова"
                    ,"1","2","null","null","Физика и астрономия","ООП","Емил Иванов Терзийски"
                    ,"1","2","null","null","Физика и астрономия","ООП","Валентина Димитрова Мутафчиева"
                    ,"1","3","null","null","Френски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"1","4","null","null","Френски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"1","5","null","null","Основи на мехатрониката","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"1","6","null","null","Теория на двигатели с вътрешно горене","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"1","7","null","null","Спортни дейности (бадминтон)","…","Костадин Стефанов Митрев"
                    ,"2","1","null","null","Физическо възпитание и спорт","ООП","Костадин Стефанов Митрев"
                    ,"2","2","null","null","Биология и здравно образование","ООП","Анелия Стоянова Калъмбова"
                    ,"2","2","null","null","Биология и здравно образование","ООП","Величка Георгиева Божинова"
                    ,"2","3","null","null","Химия и опазване на околната среда","ООП","Мая Димитрова Илиева"
                    ,"2","3","null","null","Химия и опазване на околната среда","ООП","Димитринка Любенова Мешкова"
                    ,"2","4","null","null","Химия и опазване на околната среда","ООП","Мая Димитрова Илиева"
                    ,"2","4","null","null","Химия и опазване на околната среда","ООП","Димитринка Любенова Мешкова"
                    ,"2","5","null","null","Български език и литература","ООП","Катя Иванова Петкова"
                    ,"2","5","null","null","Български език и литература","ООП","Ботьо Димитров Пенев"
                    ,"2","6","null","null","Материалознание","ИУЧ - ОтПП","Снежанка Христова Кацарова"
                    ,"2","7","null","null","Основи на хидравлични и пневматични устройства","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"3","1","null","null","Математика","ООП","Сашка Андонова Николова"
                    ,"3","1","null","null","Математика","ООП","Мариана Александрова Ризова"
                    ,"3","1","null","null","Математика","ООП","Иван Костадинов Попов"
                    ,"3","2","null","null","Математика","ООП","Сашка Андонова Николова"
                    ,"3","2","null","null","Математика","ООП","Мариана Александрова Ризова"
                    ,"3","2","null","null","Математика","ООП","Иван Костадинов Попов"
                    ,"3","3","null","null","История и цивилизации","ООП","Невена Иванова Шингарова-Кажова"
                    ,"3","4","null","null","Физическо възпитание и спорт","ООП","Костадин Стефанов Митрев"
                    ,"3","5","null","null","Български език и литература","ООП","Катя Иванова Петкова"
                    ,"3","5","null","null","Български език и литература","ООП","Ботьо Димитров Пенев"
                    ,"3","6","null","null","Български език и литература","ООП","Катя Иванова Петкова"
                    ,"3","6","null","null","Български език и литература","ООП","Ботьо Димитров Пенев"
                    ,"3","7","null","null","Час на класа","…","Костадин Стефанов Митрев"
                    ,"4","1","null","null","География и икономика","ООП","Катя Методиева Дукова"
                    ,"4","1","null","null","География и икономика","ООП","Благовест Георгиев Илиев"
                    ,"4","1","null","null","География и икономика","ООП","Стефани Николаева Мездрова-Кирова"
                    ,"4","2","null","null","Техническа механика","ИУЧ - ОтПП","Снежанка Христова Кацарова"
                    ,"4","3","null","null","Математика","ООП","Сашка Андонова Николова"
                    ,"4","3","null","null","Математика","ООП","Мариана Александрова Ризова"
                    ,"4","3","null","null","Математика","ООП","Иван Костадинов Попов"
                    ,"4","4","null","null","Философия","ООП","Роза Атанасова Иванова"
                    ,"4","4","null","null","Философия","ООП","Харалампи Иванов Иванов"
                    ,"4","4","null","null","Философия","ООП","Мария Илиева Кацарова"
                    ,"4","4","null","null","Философия","ООП","Петранка Захариева Михайлова"
                    ,"4","5","null","null","Информационни технологии","ООП","Красимира Любенова Пановска"
                    ,"4","5","null","null","Информационни технологии","ООП","Елза Василева Булакиева"
                    ,"4","6","null","null","Английски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"4","6","null","null","Английски език","ООП","Мария Василева Якимова-Кацарска"
                    ,"4","7","null","null","Английски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"4","7","null","null","Английски език","ООП","Мария Василева Якимова-Кацарска"
                    ,"5","1","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"5","1","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"5","2","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"5","2","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"5","3","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"5","3","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"5","4","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"5","4","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"5","6","null","null","Основи на хидравлични и пневматични устройства","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"5","7","null","null","Теория на двигатели с вътрешно горене","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"1","1","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"1","1","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"1","2","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"1","2","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"1","3","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"1","3","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"1","4","null","null","Учебна практика - по специалността","ИУЧ - РПП","Божидар Георгиев Цулев"
                    ,"1","4","null","null","Учебна практика - по специалността","ИУЧ - РПП","Александър Методиев Дерибанов"
                    ,"1","6","null","null","Математика","ООП","Сашка Андонова Николова"
                    ,"1","6","null","null","Математика","ООП","Мариана Александрова Ризова"
                    ,"1","6","null","null","Математика","ООП","Иван Костадинов Попов"
                    ,"1","7","null","null","Физика и астрономия","ООП","Емил Иванов Терзийски"
                    ,"1","7","null","null","Физика и астрономия","ООП","Валентина Димитрова Мутафчиева"
                    ,"2","1","null","null","Химия и опазване на околната среда","ООП","Мая Димитрова Илиева"
                    ,"2","1","null","null","Химия и опазване на околната среда","ООП","Димитринка Любенова Мешкова"
                    ,"2","2","null","null","Физическо възпитание и спорт","ООП","Костадин Стефанов Митрев"
                    ,"2","3","null","null","Български език и литература","ООП","Катя Иванова Петкова"
                    ,"2","3","null","null","Български език и литература","ООП","Ботьо Димитров Пенев"
                    ,"2","4","null","null","Български език и литература","ООП","Катя Иванова Петкова"
                    ,"2","4","null","null","Български език и литература","ООП","Ботьо Димитров Пенев"
                    ,"2","5","null","null","Философия","ООП","Роза Атанасова Иванова"
                    ,"2","5","null","null","Философия","ООП","Харалампи Иванов Иванов"
                    ,"2","5","null","null","Философия","ООП","Мария Илиева Кацарова"
                    ,"2","5","null","null","Философия","ООП","Петранка Захариева Михайлова"
                    ,"2","6","null","null","Английски език","ООП","Мария Василева Якимова-Кацарска"
                    ,"2","6","null","null","Английски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"2","7","null","null","Английски език","ООП","Мария Василева Якимова-Кацарска"
                    ,"2","7","null","null","Английски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"3","1","null","null","Техническа механика","ИУЧ - ОтПП","Снежанка Христова Кацарова"
                    ,"3","2","null","null","Материалознание","ИУЧ - ОтПП","Снежанка Христова Кацарова"
                    ,"3","3","null","null","Теория на двигатели с вътрешно горене","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"3","4","null","null","История и цивилизации","ООП","Невена Иванова Шингарова-Кажова"
                    ,"3","5","null","null","Основи на хидравлични и пневматични устройства","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"3","6","null","null","Физическо възпитание и спорт","ООП","Костадин Стефанов Митрев"
                    ,"3","7","null","null","Математика","ООП","Сашка Андонова Николова"
                    ,"3","7","null","null","Математика","ООП","Мариана Александрова Ризова"
                    ,"3","7","null","null","Математика","ООП","Иван Костадинов Попов"
                    ,"4","1","null","null","Български език и литература","ООП","Катя Иванова Петкова"
                    ,"4","1","null","null","Български език и литература","ООП","Ботьо Димитров Пенев"
                    ,"4","2","null","null","Основи на хидравлични и пневматични устройства","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"4","3","null","null","Математика","ООП","Сашка Андонова Николова"
                    ,"4","3","null","null","Математика","ООП","Мариана Александрова Ризова"
                    ,"4","3","null","null","Математика","ООП","Иван Костадинов Попов"
                    ,"4","4","null","null","География и икономика","ООП","Катя Методиева Дукова"
                    ,"4","4","null","null","География и икономика","ООП","Благовест Георгиев Илиев"
                    ,"4","4","null","null","География и икономика","ООП","Стефани Николаева Мездрова-Кирова"
                    ,"4","5","null","null","Информационни технологии","ООП","Елза Василева Булакиева"
                    ,"4","5","null","null","Информационни технологии","ООП","Красимира Любенова Пановска"
                    ,"4","6","null","null","Спортни дейности (бадминтон)","…","Костадин Стефанов Митрев"
                    ,"4","7","null","null","Теория на двигатели с вътрешно горене","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"5","1","null","null","Френски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"5","2","null","null","Френски език","ООП","Мариам Таквор Гилигян-Зарарева"
                    ,"5","3","null","null","Здравословни и безопасни условия на труд","ОбПП","Снежана Николова Маламова"
                    ,"5","4","null","null","Биология и здравно образование","ООП","Анелия Стоянова Калъмбова"
                    ,"5","4","null","null","Биология и здравно образование","ООП","Величка Георгиева Божинова"
                    ,"5","5","null","null","Основи на мехатрониката","ИУЧ - РПП","Снежанка Христова Кацарова"
                    ,"5","6","null","null","История и цивилизации","ООП","Невена Иванова Шингарова-Кажова"
                    ,"5","7","null","null","Час на класа","…","Костадин Стефанов Митрев"
                    

        };
    }
}
