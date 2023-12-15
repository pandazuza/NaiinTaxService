using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NaiinTaxService.Models
{

	public class ReqeustReceiptTaxInvoice
	{
		public string RequestSendMail { get; set; }
		public string Email { get; set; }
		public string ReplaceFlag { get; set; }
		public string Branch { get; set; }
		public string TransCode { get; set; }
		public string InternalDocNo { get; set; }
		public string FlagDocumentPrint { get; set; }
		public string PrintUser { get; set; }
		public string Document { get; set; }
		public ExchangedDocumentContext ExchangedDocumentContext { get; set; }
		public ExchangedDocument ExchangedDocument { get; set; }
		public SupplyChainTradeTransaction SupplyChainTradeTransaction { get; set; }
	}

	#region < 1. ExchangedDocumentContext บริบทของเอกสาร >
	public class DocumentContextParameterID
	{
		public string schemeAgencyID { get; set; }
		public string schemeVersionID { get; set; }
		public string Value { get; set; }
	}

	public class GuidelineSpecifiedDocumentContextParameterItem
	{
		public DocumentContextParameterID ID { get; set; }
	}

	public class ExchangedDocumentContext
	{
		public List<GuidelineSpecifiedDocumentContextParameterItem> GuidelineSpecifiedDocumentContextParameter { get; set; }
	}
	#endregion


	#region < 2. ExchangedDocument หัวเรื่องเอกสาร >
	[Description("หัวเรื่องเอกสาร")]
	public class ExchangedDocument
	{
		[Description("เลขที่เอกสาร: หมายเลขเอกสารกำกับ หรือใบรับ")]
		public string ID { get; set; }
		[Description("ชื่อเอกสาร: Refer to tab [Master].Document Name")]
		public List<string> Name { get; set; }
		[Description("รหัสประเภทเอกสาร: Refer to tab [Master].Document Type")]
		public string TypeCode { get; set; }
		[Description("วันเดือนปีและเวลา ที่ออกเอกสาร: YYYY-MM-DDThh:mm:ss")]
		public string IssueDateTime { get; set; }
		[Description("สาเหตุการออกเอกสาร: Reason description")]
		public string Purpose { get; set; }
		[Description("รหัสสาเหตุการออกเอกสาร: ")]
		public string PurposeCode { get; set; }
		[Description("เลขที่เอกสารสากล")]
		public string GlobalID { get; set; }
		[Description("วันเดือนปีและเวลา ที่สร้างเอกสาร: YYYY-MM-DDThh:mm:ss")]
		public List<string> CreationDateTime { get; set; }
		[Description("ข้อความเพิ่มเติม")]
		public List<InformationNoteItem> IncludedNote { get; set; }
	}
	#endregion


	#region < 3. SupplyChainTradeTransaction ธุรกรรมทางการค้า >
	[Description("ธุรกรรมทางการค้า")]
	public class SupplyChainTradeTransaction
	{
		[Description("ข้อตกลงทางการค้า")]
		public ApplicableHeaderTradeAgreement ApplicableHeaderTradeAgreement { get; set; }
		[Description("ข้อมูลการจัดส่งทางการค้า")]
		public ApplicableHeaderTradeDelivery ApplicableHeaderTradeDelivery { get; set; }
		[Description("ข้อมูลการชำระเงินทางการค้า")]
		public ApplicableHeaderTradeSettlement ApplicableHeaderTradeSettlement { get; set; }
		[Description("ข้อมูลรายการทางการค้า")]
		public List<IncludedSupplyChainTradeLineItemItem> IncludedSupplyChainTradeLineItem { get; set; }
	}
	#endregion


	#region < 3.1 - 3.4 Detail Data ข้อมูล อื่นๆ >
	[Description("ข้อมูล เอกสาร")]
	public class TradeParty
	{
		[Description("รหัส")]
		public List<string> id { get; set; }
		[Description("รหัสสากล")]
		public List<string> globalID { get; set; }
		[Description("ชื่อ")]
		public string name { get; set; }
		[Description("ข้อมูลการลงทะเบียนผู้เสียภาษีอากร")]
		public SpecifiedTaxRegistration specifiedTaxRegistration { get; set; }
		[Description("รายละเอียดการติดต่อ")]
		public List<DefinedTradeContactItem> definedTradeContact { get; set; }
		[Description("ที่อยู่")]
		public PostalTradeAddress postalTradeAddress { get; set; }
	}

	[Description("ข้อมูล ผู้ซื้อ-ขาย")]
	public class TradePartyBuySale
	{
		public List<string> id { get; set; }
		public List<string> globalID { get; set; }
		public string name { get; set; }
		public SpecifiedTaxRegistration SpecifiedTaxRegistration { get; set; }
		public List<DefinedTradeContactItem> DefinedTradeContact { get; set; }
		public PostalTradeAddress PostalTradeAddress { get; set; }
	}

	[Description("ข้อมูล ผู้รับ-ผู้ส่ง")]
	public class TradePartyDelivery
	{
		public List<string> id { get; set; }
		public List<string> globalID { get; set; }
		public string name { get; set; }
		public List<DefinedTradeContactItem> definedTradeContact { get; set; }
		public PostalTradeAddress postalTradeAddress { get; set; }
	}

	[Description("ข้อมูล ที่อยู่")]
	public class PostalTradeAddress
	{
		public string PostcodeCode { get; set; }
		public string BuildingName { get; set; }
		public string LineOne { get; set; }
		public string LineTwo { get; set; }
		public string LineThree { get; set; }
		public string LineFour { get; set; }
		public string LineFive { get; set; }
		public string StreetName { get; set; }
		public string CityName { get; set; }
		public string CitySubDivisionName { get; set; }
		public IdValue CountryID { get; set; }
		public string CountrySubDivisionID { get; set; }
		public string BuildingNumber { get; set; }
	}

	[Description("ข้อมูล การลงทะเบียนผู้เสียภาษีอากร")]
	public class SpecifiedTaxRegistration
	{
		public IdValue ID { get; set; }
	}

	[Description("รหัสประเทศกำเนิด")]
	public class OriginTradeCountry
	{
		public IdValue id { get; set; }
	}

	[Description("ข้อมูล รายละเอียดการติดต่อ")]
	public class DefinedTradeContactItem
	{
		public string personName { get; set; }
		public string departmentName { get; set; }
		public EmailURIUniversalCommunication emailURIUniversalCommunication { get; set; }
		public TelephoneUniversalCommunication telephoneUniversalCommunication { get; set; }
	}

	[Description("ข้อมูล ภาษี")]
	public class ApplicableTradeTaxItem
	{
		[Description("รหัสประเภทภาษี: VAT = Value Added Tax, FRE = Free no tax")]
		public string TypeCode { get; set; }
		[Description("อัตราภาษี")]
		public string CalculatedRate { get; set; }
		[Description("มูลค่าสินค้า/บริการที่นำมาคิดภาษี (ไม่รวมภาษีมูลค่าเพิ่ม ทศนิยม 2 ตำแหน่ง)")]
		public List<string> BasisAmount { get; set; }
		[Description("มูลค่าภาษี (ทศนิยม 2 ตำแหน่ง)")]
		public List<string> CalculatedAmount { get; set; }
	}

	[Description("ข้อมูล ส่วนลดหรือค่าธรรมเนียม")]
	public class SpecifiedTradeAllowanceChargeItem
	{
		public bool chargeIndicator { get; set; }
		public List<string> actualAmount { get; set; }
		public string reasonCode { get; set; }
		public string reason { get; set; }
		public string typeCode { get; set; }
	}

	[Description("จำนวน")]
	public class Quantity
	{
		[Description("หน่วยของสินค้า")]
		public string unitCode { get; set; }
		[Description("จำนวนสินค้า")]
		public string Value { get; set; }
	}

	[Description("จำนวนเงิน")]
	public class AmountItem
	{
		[Description("หน่วย: THB")]
		public string currencyID { get; set; } = "THB";
		[Description("จำนวน: #.00")]
		public string value { get; set; }
	}

	[Description("จำนวนเงิน")]
	public class TotalAmountItem
	{
		[Description("หน่วย: THB")]
		public string currencyID { get; set; }
		public string currencyCodeListVersionID { get; set; }
		[Description("จำนวน: #.00")]
		public string value { get; set; }
	}

	[Description("ID Value")]
	public class IdValue
	{
		public string schemeID { get; set; }
		public string value { get; set; }
	}

	[Description("การติดต่อทางอีเมล")]
	public class EmailURIUniversalCommunication
	{
		public string uriid { get; set; }
	}

	[Description("การติดต่อทางโทรศัพท์")]
	public class TelephoneUniversalCommunication
	{
		public string completeNumber { get; set; }
	}

	[Description("ข้อความเพิ่มเติม")]
	public class InformationNoteItem
	{
		[Description("หัวข้อ")]
		public string subject { get; set; }
		[Description("เนื้อหา")]
		public List<string> content { get; set; }
	}
	#endregion


	#region < 3.1 ApplicableHeaderTradeAgreement ข้อตกลงทางการค้า >
	[Description("ข้อตกลงทางการค้า")]
	public class ApplicableHeaderTradeAgreement
	{
		public TradePartyBuySale SellerTradeParty { get; set; }
		public TradePartyBuySale BuyerTradeParty { get; set; }
		public ApplicableTradeDeliveryTerms ApplicableTradeDeliveryTerms { get; set; }
		public ReferencedDocument BuyerOrderReferencedDocument { get; set; }
		public List<ReferencedDocument> AdditionalReferencedDocument { get; set; }
	}

	[Description("เงื่อนไขหรือข้อกำหนดการส่งสินค้า")]
	public class ApplicableTradeDeliveryTerms
	{
		public string deliveryTypeCode { get; set; }
	}

	[Description("เอกสารอ้างอิง")]
	public class ReferencedDocument
	{
		[Description("เลขที่เอกสารอ้างอิง")]
		public string issuerAssignedID { get; set; }
		[Description("วันเดือนปี ที่ออกเอกสารอ้างอิง: YYYY-MM-DDThh:mm:ss.sssZ")]
		public string issueDateTime { get; set; }
		[Description("รหัสระบุประเภทเอกสารอ้างอิง")]
		public string referenceTypeCode { get; set; }
	}
	#endregion


	#region < 3.2 ApplicableHeaderTradeDelivery ข้อมูลการจัดส่งทางการค้า >
	[Description("ข้อมูลการจัดส่งทางการค้า")]
	public class ApplicableHeaderTradeDelivery
	{
		[Description("ข้อมูลผู้รับ")]
		public TradePartyDelivery shipToTradeParty { get; set; }
		[Description("ข้อมูลผู้ส่ง")]
		public TradePartyDelivery shipFromTradeParty { get; set; }
		public ActualDeliverySupplyChainEvent actualDeliverySupplyChainEvent { get; set; }
	}

	[Description("การนัดส่งสินค้า")]
	public class ActualDeliverySupplyChainEvent
	{
		public string occurrenceDateTime { get; set; }
	}

	#endregion


	#region < 3.3 ApplicableHeaderTradeSettlement ข้อมูลการชำระเงินทางการค้า >
	[Description("ข้อมูลการชำระเงินทางการค้า")]
	public class ApplicableHeaderTradeSettlement
	{
		public InvoiceCurrencyCode InvoiceCurrencyCode { get; set; }
		public List<ApplicableTradeTaxItem> ApplicableTradeTax { get; set; }
		public List<SpecifiedTradeAllowanceChargeItem> SpecifiedTradeAllowanceCharge { get; set; }
		public List<SpecifiedTradePaymentTermsItem> SpecifiedTradePaymentTerms { get; set; }
		public SpecifiedTradeSettlementHeaderMonetarySummation SpecifiedTradeSettlementHeaderMonetarySummation { get; set; }
		[Description("ผู้ออกเอกสารแทน")]
		public TradeParty invoicerTradeParty { get; set; }
		[Description("ผู้รับเอกสาร")]
		public TradeParty invoiceeTradeParty { get; set; }
		[Description("ผู้ชำระเงิน")]
		public TradeParty payerTradeParty { get; set; }
		[Description("ผู้รับชำระเงิน")]
		public TradeParty payeeTradeParty { get; set; }
	}

	[Description("รหัสสกุลเงินตรา: Currency code listID")]
	public class InvoiceCurrencyCodeList
	{
		public string listID { get; set; }
		public string listAgencyID { get; set; }
		public string listVersionID { get; set; }
		public string listURI { get; set; }
		public string value { get; set; }
	}

	[Description("รหัสสกุลเงินตรา: Currency code")]
	public class InvoiceCurrencyCode
	{
		public string value { get; set; }
	}

	[Description("ข้อมูลการชำระเงิน")]
	public class SpecifiedTradePaymentTermsItem
	{
		public string typeCode { get; set; }
		public List<string> description { get; set; }
		public string dueDateDateTime { get; set; }
	}

	[Description("การสรุปมูลค่าการชำระเงินทางการค้า")]
	public class SpecifiedTradeSettlementHeaderMonetarySummation
	{
		public string OriginalInformationAmount { get; set; }
		public List<AmountItem> LineTotalAmount { get; set; }
		public string DifferenceInformationAmount { get; set; }
		public List<AmountItem> AllowanceTotalAmount { get; set; }
		public string ChargeTotalAmount { get; set; }
		public List<AmountItem> TaxBasisTotalAmount { get; set; }
		public List<AmountItem> TaxTotalAmount { get; set; }
		public List<AmountItem> GrandTotalAmount { get; set; }
	}
	#endregion


	#region < 3.4 IncludedSupplyChainTradeLineItem ข้อมูลรายการทางการค้า >
	[Description("ข้อมูลรายการทางการค้า")]
	public class IncludedSupplyChainTradeLineItemItem
	{
		public AssociatedDocumentLineDocument AssociatedDocumentLineDocument { get; set; }
		public SpecifiedTradeProduct SpecifiedTradeProduct { get; set; }
		public SpecifiedLineTradeAgreement SpecifiedLineTradeAgreement { get; set; }
		public SpecifiedLineTradeDelivery SpecifiedLineTradeDelivery { get; set; }
		public SpecifiedLineTradeSettlement SpecifiedLineTradeSettlement { get; set; }
	}

	[Description("ข้อมูลระบุรายการซื้อขาย")]
	public class AssociatedDocumentLineDocument
	{
		public string LineID { get; set; }
	}

	[Description("ข้อมูลสินค้า")]
	public class SpecifiedTradeProduct
	{
		public string ID { get; set; }
		public string GlobalID { get; set; }
		public List<string> Name { get; set; }
		public List<string> Description { get; set; }
		public List<IndividualTradeProductInstanceItem> IndividualTradeProductInstance { get; set; }
		public DesignatedProductClassification DesignatedProductClassification { get; set; }
		public OriginTradeCountry OriginTradeCountry { get; set; }
		public List<InformationNoteItem> InformationNote { get; set; }
	}

	[Description("ข้อตกลงทางการค้า")]
	public class SpecifiedLineTradeAgreement
	{
		public GrossPriceProductTradePrice GrossPriceProductTradePrice { get; set; }
	}

	[Description("ข้อมูลการจัดส่งทางการค้า")]
	public class SpecifiedLineTradeDelivery
	{
		[Description("จำนวนสินค้า (ในกรณีที่เป็นการขายสินค้าจะต้องส่ง Quantity, ส่วนกรณีพวกค่าบริการ,ค่าเช่า ให้ส่งค่า `1`)")]
		public Quantity BilledQuantity { get; set; }
		[Description("ขนาดบรรจุต่อหน่วยขาย")]
		public Quantity PerPackageUnitQuantity { get; set; }
	}

	[Description("ข้อมูลการชำระเงินทางการค้า")]
	public class SpecifiedLineTradeSettlement
	{
		public List<ApplicableTradeTaxItem> ApplicableTradeTax { get; set; }
		public List<SpecifiedTradeAllowanceChargeItem> SpecifiedTradeAllowanceCharge { get; set; }
		public SpecifiedTradeSettlementLineMonetarySummation SpecifiedTradeSettlementLineMonetarySummation { get; set; }
	}

	[Description("การสรุปมูลค่าการชำระเงินทางการค้า")]
	public class SpecifiedTradeSettlementLineMonetarySummation
	{
		public List<AmountItem> TaxTotalAmount { get; set; }
		public List<AmountItem> NetLineTotalAmount { get; set; }
		public List<TotalAmountItem> NetIncludingTaxesLineTotalAmount { get; set; }
	}

	[Description("ข้อมูล สินค้าที่จัดส่ง")]
	public class IndividualTradeProductInstanceItem
	{
		[Description("ครั้งที่ผลิต")]
		public string batchID { get; set; }
		[Description("วันหมดอายุ: YYYY-MM-DDThh:mm:ss.sssZ")]
		public string expiryDateTime { get; set; }
	}

	[Description("ข้อมูล หมวดหมู่สินค้า")]
	public class DesignatedProductClassification
	{
		[Description("รหัสหมวดหมู่สินค้า")]
		public string classCode { get; set; }
		[Description("ชื่อหมวดหมู่สินค้า")]
		public List<string> className { get; set; }
	}

	[Description("ข้อมูลจำนวนเงินสินค้าต่อหน่วย")]
	public class GrossPriceProductTradePrice
	{
		[Description("ราคาต่อหน่วย")]
		public List<AmountItem> ChargeAmount { get; set; }
		[Description("ข้อมูลส่วนลดหรือค่าธรรมเนียม")]
		public List<AppliedTradeAllowanceChargeItem> AppliedTradeAllowanceCharge { get; set; }
	}

	[Description("ข้อมูลส่วนลดหรือค่าธรรมเนียม")]
	public class AppliedTradeAllowanceChargeItem
	{
		[Description("ตัวบอกส่วนลดหรือค่าธรรมเนียม (ต่อหน่วย)")]
		public bool chargeIndicator { get; set; }
		[Description("มูลค่าส่วนลดหรือค่าธรรมเนียม (ต่อหน่วย)")]
		public List<string> actualAmount { get; set; }
		[Description("รหัสประเภทส่วนลดหรือค่าธรรมเนียม (ต่อหนวย)")]
		public string reasonCode { get; set; }
		[Description("เหตุผลในการคิดค่าธรรมเนียม หรือส่วนลด (ต่อหน่วย)")]
		public string reason { get; set; }
		[Description("รหัสประเภทส่วนลดหรือค่าธรรมเนียม")]
		public string typeCode { get; set; }
	}
	#endregion

}