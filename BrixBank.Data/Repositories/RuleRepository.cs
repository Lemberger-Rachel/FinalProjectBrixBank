using BrixBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;
using BrixBank.Data.Entities;

namespace BrixBank.Data.Repositories
{
   public class RuleRepository: IRuleRepository
    {
        private readonly BrixBankContext _context;

        public RuleRepository(BrixBankContext context)
        {
            _context = context;
        }

        public void ReadExcelFile()
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string custId="";
                var listRule = new List<string>();
                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(@"C:\Users\RLemberger\Documents\Brix\FinalProject\BrixBank\BrixBank.Data\bin\Debug\netcoreapp3.1\book1.xlsx", false))
                {
                    //create the object for workbook part  
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                    StringBuilder excelResult = new StringBuilder();

                    //using for each loop to get the sheet from the sheetcollection  
                    foreach (Sheet thesheet in thesheetcollection)
                    {
                        excelResult.AppendLine("Excel Sheet Name : " + thesheet.Name);
                        //statement to get the worksheet object by using the sheet id  

                        Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;
                        SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();
                        foreach (Row thecurrentrow in thesheetdata)
                        {
                            foreach (Cell thecurrentcell in thecurrentrow)
                            {
                                //statement to take the integer value  
                                string currentcellvalue = string.Empty;
                                if (thecurrentcell.DataType != null)
                                {
                                    if (thecurrentcell.DataType == CellValues.SharedString)
                                    {
                                        int id;
                                        if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                        {
                                            SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                            listRule.Add(item.InnerText.ToString());
                                            custId = thesheet.Name;
                                            if (item.Text != null)
                                            {
                                                //code to take the string value  
                                                excelResult.Append(item.Text.Text + " ");
                                            }
                                            else if (item.InnerText != null)
                                            {
                                                currentcellvalue = item.InnerText;
                                            }
                                            else if (item.InnerXml != null)
                                            {
                                                currentcellvalue = item.InnerXml;
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    excelResult.Append(Convert.ToInt16(thecurrentcell.InnerText) + " ");
                                }
                            }

                            excelResult.AppendLine();
                        }
                        excelResult.Append("");
                    }
                }
                Customer customer = _context.Customers.FirstOrDefault(c => c.Name == custId);
                if (customer == null)
                {
                     customer = new Customer();
                     customer.Name = custId;
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                }
                foreach (var item in listRule)
                {
                    Rules rule = new Rules();
                    string itemParse = ParseExp(item);
                    string[] collection = itemParse.Split(';');
                    rule.Kind = collection[0];
                    rule.Operator = collection[1];
                    rule.Output = Int32.Parse(collection[2]);
                    rule.Law = itemParse;
                    rule.CustomerId2 = customer;
                    _context.Rules.Add(rule);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string ParseExp(string expr)
        {
            string[] ops = { ">=", "<=", "==", "<", ">" };
            string passExpr = expr;
            foreach (var op in ops)
            {
                passExpr = expr.Replace(op, ";" + op + ";");
                if (!passExpr.Equals(expr))
                {
                    break;
                }
            }
            return passExpr;
        }
    }
}
