using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.DataSet
{
    public class UnloadBunker
    {
        public DateTime Дата_и_время { get; set; }
        public int? Номер_порции { get; set; }
        public int Бункер { get; set; }
        public string Материал { get; set; }
        public string Материал_по_факту { get; set; }
        public float? Угол_открытия_ШЗ_фактический { get; set; }
        public float? Угол_открытия_ШЗ_расчетный { get; set; }
        public float? Скорость_выгрузки_фактическая { get; set; }
        public float? Скорость_выгрузки_расчетная { get; set; }
        public float? Время_выгрузки { get; set; }
        public float? Масса { get; set; }
        public float? Вес_тары { get; set; }
        public float? Выгружено_в_позицию_1 { get; set; }
        public float? Выгружено_в_позицию_2 { get; set; }
        public float? Выгружено_в_позицию_3 { get; set; }
        public float? Выгружено_в_позицию_4 { get; set; }
        public float? Выгружено_в_позицию_5 { get; set; }
        public float? Выгружено_в_позицию_6 { get; set; }
        public float? Выгружено_в_позицию_7 { get; set; }
        public float? Выгружено_в_позицию_8 { get; set; }
        public float? Выгружено_в_позицию_9 { get; set; }
        public float? Выгружено_в_позицию_10 { get; set; }
        public float? Выгружено_в_позицию_11 { get; set; }
        public float? Выгружено_между_позициями_1_2 { get; set; }
        public float? Выгружено_между_позициями_2_3 { get; set; }
        public float? Выгружено_между_позициями_3_4 { get; set; }
        public float? Выгружено_между_позициями_4_5 { get; set; }
        public float? Выгружено_между_позициями_5_6 { get; set; }
        public float? Выгружено_между_позициями_6_7 { get; set; }
        public float? Выгружено_между_позициями_7_8 { get; set; }
        public float? Выгружено_между_позициями_8_9 { get; set; }
        public float? Выгружено_между_позициями_9_10 { get; set; }
        public float? Выгружено_между_позициями_10_11 { get; set; }
        public float? Выгружено_после_позиции_11 { get; set; }
        public float? Задание_на_позицию_1 { get; set; }
        public float? Задание_на_позицию_2 { get; set; }
        public float? Задание_на_позицию_3 { get; set; }
        public float? Задание_на_позицию_4 { get; set; }
        public float? Задание_на_позицию_5 { get; set; }
        public float? Задание_на_позицию_6 { get; set; }
        public float? Задание_на_позицию_7 { get; set; }
        public float? Задание_на_позицию_8 { get; set; }
        public float? Задание_на_позицию_9 { get; set; }
        public float? Задание_на_позицию_10 { get; set; }
        public float? Задание_на_позицию_11 { get; set; }
        public float? Выгружено_в_сектор_1 { get; set; }
        public float? Выгружено_в_сектор_2 { get; set; }
        public float? Выгружено_в_сектор_3 { get; set; }
        public float? Выгружено_в_сектор_4 { get; set; }
        public float? Выгружено_в_сектор_5 { get; set; }
        public float? Выгружено_в_сектор_6 { get; set; }
        public float? Отработанный_угол_лотка_1 { get; set; }
        public float? Отработанный_угол_лотка_2 { get; set; }
        public float? Отработанный_угол_лотка_3 { get; set; }
        public float? Отработанный_угол_лотка_4 { get; set; }
        public float? Отработанный_угол_лотка_5 { get; set; }
        public float? Отработанный_угол_лотка_6 { get; set; }
        public float? Отработанный_угол_лотка_7 { get; set; }
        public float? Отработанный_угол_лотка_8 { get; set; }
        public float? Отработанный_угол_лотка_9 { get; set; }
        public float? Отработанный_угол_лотка_10 { get; set; }
        public float? Отработанный_угол_лотка_11 { get; set; }
        public float? Число_импульсов_на_перевод_лотка { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_1 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_2 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_3 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_4 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_5 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_6 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_7 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_8 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_9 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_10 { get; set; }
        public float? Дистанция_при_переводе_лотка_на_угол_11 { get; set; }
        public float? Управление_по_массе_при_высыпании { get; set; }
        public float? Нижнее_положение_зонд_1 { get; set; }
        public float? Нижнее_положение_зонд_2 { get; set; }
        public float? Нижнее_положение_зонд_3 { get; set; }
        public float? Нижнее_положение_зонд_4 { get; set; }
        public float? Задание_уровень_засыпи { get; set; }
        public float? Точность_рассыпания { get; set; }
    }
}
