namespace Models.ViewModels
{
    public class ShowCalc
    {
        public string CalcPrice { get; set; } //price of property, charged from _show(flat,house,land).cshtml
        public double CalcCLAT { get; set; } // Civil law transaction tax. 
        public string CalcOwnershipForm { get; set; } //ownership form: Spółdzielcze własnościowe prawo, Spółdzielcze własnościowe prawo z księgą wieczystą , Własność hipoteczna 
        public double CalcNotary { get; set; } //notary tax
        public double CalcVATNotary { get; set; } // notary tax VAT
        public double CalcCourtFee { get; set; } /*if CalcOwnershipForm = Spółdzielcze własnościowe prawo, CalcCourtFee = 0
                                                   if CalcOwnershipForm = Spółdzielcze własnościowe prawo z księgą wieczystą, CalcCourtFee = 200?
                                                   if CalcOwnershipForm = Własność hipoteczna, CalcCourtFee = 200? */
        public double CalcMR { get; set; } //mortgage register - if CalcOwnershipForm = Spółdzielcze własnościowe prawo z księgą wieczystą, CalcMR = 40; other = 0;
        public double CalcAgencyCommissionPercent { get; set; } //Agency Commission Percent = charged from ///utworzyc klase oplat dodatkowych w admin
        public double CalcAgencyCommission { get; set; } //CalcAgencyCommissionPercent * CalcPrice
        public double CalcVATAgencyCommission { get; set; } //CalcAgencyCommissionPercent * CalcPrice * VAT charged from XXX
        public double CalcApproxCost { get; set; } // the estimated additional costs
        public double CalcActPagePrice { get; set; } //extract act cost per page
        public double CalcTotalCost { get; set; } // total cost CalcPrice+CalcApproxCost
    }
}