using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms;

namespace ZebraBarPrintApp
{
    public class UpcLabel
    {

        public void PrintBarcode(string printerName, string pProductName, string pRetail, 
            string pBarcode, string strNumOfCopies, string BarcodeType)
        {
            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }
            StringBuilder strBldr = ReviewBarcode(pProductName, pRetail, pBarcode, strNumOfCopies, BarcodeType);
            RawPrinterHelper.SendStringToPrinter(printerName, strBldr.ToString()); 
        }

        public StringBuilder ReviewBarcode(string pProductName, string pRetail, string pBarcode, string strNumOfCopies, string BarcodeType)
        {
            
            StringBuilder barcodeStr = new StringBuilder();
            StringBuilder itemInfoStr = new StringBuilder();
            StringBuilder labelStr = new StringBuilder();
            SymbolParams BarcodeParams = new SymbolParams();
            SymbolParams ItemInfoParams = new SymbolParams();
            if (BarcodeType == "")
            {
                labelStr = GenerateZplCodeNull(pProductName, pRetail, pBarcode, strNumOfCopies);
                MessageBox.Show("Error: Bar code type is missing");
            }
            else if (BarcodeType == "Code 128")
            {
                ItemInfoParams.fromLeft = 40;
                ItemInfoParams.fromTop = 100;
                ItemInfoParams.height = 50;
                ItemInfoParams.width = 50;
                itemInfoStr = GenerateZplItemInfo(pProductName, pRetail, ItemInfoParams);
                //
                BarcodeParams.fromLeft = 80;
                BarcodeParams.fromTop = 200;
                BarcodeParams.height = 125;
                BarcodeParams.BYvalue = 3;
                barcodeStr = GenerateZplCode128(pBarcode, strNumOfCopies, BarcodeParams);
                //
                labelStr.AppendLine("^XA");
                labelStr.AppendLine(itemInfoStr.ToString());
                labelStr.AppendLine(barcodeStr.ToString());
                labelStr.AppendLine("^XZ");
            }
            else if (BarcodeType == "Code 39")
            {
                ItemInfoParams.fromLeft = 40;
                ItemInfoParams.fromTop = 100;
                ItemInfoParams.height = 50;
                ItemInfoParams.width = 50;
                itemInfoStr = GenerateZplItemInfo(pProductName, pRetail, ItemInfoParams);
                //
                BarcodeParams.fromLeft = 80;
                BarcodeParams.fromTop = 200;
                BarcodeParams.height = 125;
                BarcodeParams.BYvalue = 3;
                barcodeStr = GenerateZplCode39(pBarcode, strNumOfCopies, BarcodeParams);
                //
                labelStr.AppendLine("^XA");
                labelStr.AppendLine(itemInfoStr.ToString());
                labelStr.AppendLine(barcodeStr.ToString());
                labelStr.AppendLine("^XZ");
            }
            else if (BarcodeType == "Code 128 | 1/2\" x 2-1/4\"")
            {
                BarcodeParams.fromLeft = 220;
                BarcodeParams.fromTop = 20;
                BarcodeParams.height = 60;
                BarcodeParams.BYvalue = 2;
                barcodeStr = GenerateZplCode128(pBarcode, strNumOfCopies, BarcodeParams);
                //
                labelStr.AppendLine("^XA");
                labelStr.AppendLine(barcodeStr.ToString());
                labelStr.AppendLine("^XZ");
            }
            else
            {
                labelStr = GenerateZplCodeNull(pProductName, pRetail, pBarcode, strNumOfCopies);
            }
            return labelStr;
        }

        public StringBuilder GenerateZplItemInfo(string pProductName, string pRetail, SymbolParams ItemInfoParams)
        {
            StringBuilder strBldr = new StringBuilder();
            //strBldr.AppendLine("^FO40,100");
            //strBldr.AppendLine("^AQ,50,30");
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture,
                "^FO{0}, {1}",
                ItemInfoParams.fromLeft.ToString(),
                ItemInfoParams.fromTop.ToString()
                ));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture,
                "^AQ,{0},{1}",
                ItemInfoParams.height.ToString(),
                ItemInfoParams.width.ToString()
                ));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture, "^FD{0}^FS", '$'+pRetail + ' ' + pProductName));
            return strBldr;
        }
        public StringBuilder GenerateZplCode39(string pBarcode, string strNumOfCopies, SymbolParams parameters)
        {

            StringBuilder strBldr = new StringBuilder();
            //strBldr.AppendLine("^XA");
            //strBldr.AppendLine("^FO80,200^BY3");
            //strBldr.AppendLine("^BCN,125,Y,N,Y,N");
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture, 
                "^FO{0}, {1}^BY{2}", 
                parameters.fromLeft.ToString(), 
                parameters.fromTop.ToString(),
                parameters.BYvalue.ToString()
                ));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture,
                "^B3N,N, {0}, Y, N", 
                parameters.height.ToString()
                ));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture, "^FD{0}^FS", pBarcode));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture, "^PQ{0}", strNumOfCopies));
            //strBldr.AppendLine("^XZ");
            return strBldr;
        }
        public StringBuilder GenerateZplCode128(string pBarcode, string strNumOfCopies, SymbolParams parameters)
        {
            StringBuilder strBldr = new StringBuilder();
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture,
                "^FO{0}, {1}^BY{2}",
                parameters.fromLeft.ToString(),
                parameters.fromTop.ToString(),
                parameters.BYvalue.ToString()
                 ));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture,
                "^BCN,{0},Y,N,N",
                parameters.height.ToString()
                ));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture, "^FD{0}^FS", pBarcode));
            strBldr.AppendLine(string.Format(CultureInfo.InvariantCulture, "^PQ{0}", strNumOfCopies));
            return strBldr;
        }
        public StringBuilder GenerateZplCodeNull(string pProductName, string pRetail, string pBarcode, string strNumOfCopies)
        {
            StringBuilder strBldr = new StringBuilder();
            strBldr.AppendLine(pProductName);
            strBldr.AppendLine(pRetail);
            strBldr.AppendLine(pBarcode);
            return strBldr;
        }
    }
}
