using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace api;

public class EPPLUSExample
{
  public void Export()
  {
    var vendas = new List<(string Codigo, DateTime Data)>();

    var excel = new ExcelPackage();

    var workSheet = excel.Workbook.Worksheets.Add("Relatório");

    workSheet.Cells[1, 1].Value = "Venda";
    workSheet.Cells[1, 2].Value = "Data";

    int row = 2;

    foreach (var venda in vendas)
    {
      workSheet.Cells[row, 1].Value = venda.Codigo;
      workSheet.Cells[row, 2].Value = venda.Data;
      row++;
    }
  }
}
