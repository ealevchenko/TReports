using EFBF7.DataSet;
using EFBF8.DataSet;
using EFBF9.DataSet;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport;
using libClass;

namespace Testing
{
    class Program
    {
        public static void Main(string[] args)
        {

            #region Test_EFBF7
            Test_EFBF7 tefbf7 = new Test_EFBF7();
            //tefbf7.GetBF7EnergySutkit(); // Получить энерго ресурсы за уазаную дату
            #endregion

            #region Test_EFBF8
            Test_EFBF8 tefbf8 = new Test_EFBF8();
            //tefbf8.GetBF8EnergySutkit(); // Получить энерго ресурсы за уазаную дату
            #endregion

            #region Test_EFBF9
            Test_EFBF9 tefbf9 = new Test_EFBF9();
            //tefbf9.GetBF9EnergySutkit(); // Получить энерго ресурсы за уазаную дату
            #endregion

            #region Test_TREnergy
            Test_TREnergy ttre = new Test_TREnergy();
            //ttre.GetEnergySutkit(); // Получить энерго ресурсы за уазаную дату по всем печам
            //ttre.GetResources(); // тест ресурсов
            //ttre.GetEnergyFlowDay(); // тест ресурсов за сутки
            //ttre.GetEnergyDay(); // тест ресурсов за сутки
            //ttre.GetEnergyGranulDay(); // тест ресурсов за сутки
            ttre.GetReportsEnergy(); // тест всех ресурсов за сутки

            #endregion

            #region Test_EFDataSet
            Test_EFDataSet tds = new Test_EFDataSet();
            //tds.EFDataSet_TRDataSet(); //Проверка работы dataset
            //tds.EFDataSet_TRTags(); //Проверка работы tags
            #endregion

            #region Test_TDataSources
            Test_TDataSources ttds = new Test_TDataSources();
            //ttds.GetDataMeasurement(); // Проверка получения данных по id
            #endregion

            #region Test_Forms
            Test_Forms fors = new Test_Forms();
            //fors.CreateFormEnergyDay(); // Создание формы отчета среднесут энергоресурсов
            //fors.ConvertFormEnergyFlowDayToForm(); // конвертировать в новую форму
            //fors.ConvertFormEnergyDayToForm(); // конвертировать в новую форму
            //fors.CreateFormEnergyGranulDay(); // Создать форму по грануляции шлака
            //fors.GetDBForms(); // считать все формы
            #endregion

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
