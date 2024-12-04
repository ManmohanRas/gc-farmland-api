INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
	 1, 
 'CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE', 
 'Change status from Agreement Approved to Active', 
 'Term Program - {{FarmName}}', 

'<p>Dear {{PrimaryContactName}},</p>
<p>Please take notice that the following property has been enrolled in a Farmland Preservation Program for a period of sixteen years:</p>
 <p>LandOwner: {{OwnerFirst}}, {{OwnerLast}} </p>
 <p>Municipality: {{Municipality}}</p>
 <p>Block/Lots: {{Block}}, {{Lot}}</p>
 <p> Deed Book/Page: {{DeedBook}}, {{DeedPage}}</p>
 <p>A copy of the Agreement is enclosed for your records.</p>
 <p>If you have any questions, please contact me at (973) 829 8120 or at kcoyle@co.morris.nj.us.<br>
 <p>Per N.J.A.C. 2:76-3.8, the Notice is also being forwarded to:
<p> Landowner</p>
<p> Morris County Board of Chosen Freeholders</p>
<p> Morris County Planning Board</p>
<p> Municipal Governing Body</p>
<p> Municipal Planning Board</p>
<p> Municipal Tax Assessor</p>
<p> Morris County Soil Conservation District</p>
 <br>
<p>Sincerely,</p>
<p>{{ProgramAdmin}}<br>

<p>Director</p>
Morris County Agriculture Development Board<br>
Morris County Office of Planning & Preservation<br>
P.O. Box 900<br>
Morristown, NJ 07963-0900<br>
Phone: (973) 829-8120
Fax: (973) 326-9025<br>
E-Mail: kcoyle@co.morris.nj.us<br>
Website: https://www.morriscountynj.gov/agriculture </p>', 
    1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   2, 'TRIGER_THE_EMAIL_WHEN_SADC_IS_ENABLED',
		'Triger The Email When SADC is Eanbled',
		' Term Program - {{Block}}, {{Lot}}, {{Municipality}}', 

		'<P>Dear {{SADCContact}},</P>
		<P>Pursuant to N.J.A.C. 2:76-3.6, the Morris County Agriculture Development Board (Morris CADB) 
		hereby submits a request for Certification of a Farmland Preservation Program (Term-Year Program) 
		for the above referenced property.</P>
		<p>Petition;</p>
		<p>Signed original copy of the Agreement;</p>
		<p>Morris CADB resolution;</p>
		<p>Copy of owner of last record search.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		<p>Sincerely,</p>
		<p>{{ProgramAdmin}}<br>

		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.gov/agriculture </p>', 

2);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   3,	'CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED', 
		'Change status from Requested to Approved', 
		'Term Program - {{FarmName}}', 

		'<P>Dear {{PrimaryContactName}},</P>
		<P>I am pleased to forward to you the Term Farmland Preservation Program Agreement for your property.</p> 
		<p>Please sign the document before a witness (notary public) and have the witness attest the signature. Once signed, please return the document to me</p>
		<p>I will then present the document for signature to the Morris County Agriculture Development Board (CADB) and to the State Agriculture Development Committee (SADC) for certification. Lastly, the County will record the document in the Hall of Records.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		<p>Sincerely,</p>
		<p>{{ProgramAdmin}}<br>

		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.gov/agriculture </p>', 

3);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   4,	'CHANGE_STATUS_FROM_DRAFT_TO_REQUESTED', 
		'Change status from Draft to Requested', 
		'Term Program - {{FarmName}}', 

		'<P>Dear {{PrimaryContactName}},</P>
		<P>I am in receipt of your Petition document and have added this item to the Morris CADB’s {{NextMeetingDate}} meeting agenda. The board will discuss the matter and if found acceptable, will direct staff to prepare a resolution approving the Petition.</p> 
		<p>By copy of this letter, per N.J.A.C. 2:76-3.5, I am requesting that the Morris County Counsel’s Office order an “owner of last record” title search, verifying your ownership of the land.</p>
		<p>Approval of the Petition by the CADB and creation of the farmland preservation program will be signified by an agreement between you and the CADB to retain the land in agricultural production for a minimum period of eight years.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		<p>Sincerely,</p>
		<p>{{ProgramAdmin}}<br>

		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.gov/agriculture </p>', 

4);
GO


--Easement 
INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
5,		'CHANGE_STATUS_FROM_CREATE_TO_DRAFT_APPLICATION', 
		'Change status From Create to Draft Application', 

		'<p>Farm Land Preservation Program.</p>', 

		'<p>Dear {{PrimaryContactName}},</p>
		 <p>Thank you for your interest in the Morris County Farmland Preservation Program. Please complete and submit the application. I am happy to provide help with completing the application by phone, e-mail or in person. </p>
		 <p>I look forward to working with you and welcome any questions you may have.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>

		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.gov/agriculture </p>', 
1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
6,		'CHANGE_STATUS_FROM_DRAFT_APPLICATION_TO_APPLICATION_SUBMITTED', 
		'Change status From Draft Application to Application Submitted',
		'<p>Farm Land Preservation Program.</p>',
		'<p>Dear {{PrimaryContactName}},</p>
		 <p>Thank you for submitting your application. we will review the application and, if any additional information is needed, we will contact you. </p>
		 <p>I look forward to working with you and welcome any questions you may have.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.gov/agriculture </p>', 
1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
7,		'CHANGE_STATUS_FROM_IN_REVIEW_TO_PENDING', 
		'Change status From In_Review to Pending',
		'<p>Easement Purchase Program - {{FarmName}}</p>',
		'<p>Congratulations, {{PrimaryContactName}}!</p>
		<p>At its {{PreviousMeetingDate}} meeting, the Morris County Agriculture Development Board (CADB) granted preliminary approval of your application to sell a development easement. A copy of the resolution is enclosed.</p>
		<p>Also enclosed you will find &ldquo;Notice to Proceed&rdquo; and &ldquo;Notice of Withdrawal&rdquo; forms. Please complete the appropriate form and return it to the Morris CADB before (insert due date).</p>
		<p>If you wish to continue with the preservation process, please also include your $1,000 application fee (see enclosed Morris CADB Policy P-3). A check for the application fee should be made out to &ldquo;Treasurer of Morris County.&rdquo; The application fee will be refunded upon successful sale of the development easement, or if the Morris CADB decides against purchase of the development easement. The $1,000 application fee will be forfeited if you decide to withdraw at any point prior to the closing of the development easement purchase.</p>
         <p>The Morris CADB looks forward to working with you to see your farm permanently preserved. If you have any questions, please contact Ms. Katherine Coyle at (973) 829-8120 or via e-mail at kcoyle@co.morris.nj.us.</p>
		  <p>Sincerely</p>
	     <p>{{ProgramAdmin}}<br>
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.gov/agriculture </p>', 
1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
8,		'CHANGE_STATUS_FROM_IN_REVIEW_TO_REJECTED', 
		'Change status From In_Review to Rejected',
		'Easement Purchase Program - {{FarmName}}',
		'<p>Dear {{PrimaryContactName}}:</p>

<p>At its {{PreviousMeetingDate}} meeting, the Morris County Agriculture Development Board (CADB) reviewed your application for the sale of development easement.</p>

<p> Although the merit of your application is worthwhile, I must regretfully inform you that your application was not selected. Applications are selected for a combination of reasons including: significance and financial viability of the agricultural operation, soils, amount of tillable acreage, stewardship of the land, asking price, total acquisition cost, the likelihood the property would be sold in the near future for development, the location to other preserved lands, as well as the location within Morris County.</p>

<p> The board thanks you for your continued interest in supporting preservation of farmland in our county. If you have any questions, please do not hesitate to contact Ms. Katherine Coyle at (973) 829-8120 or via e-mail at kcoyle@co.morris.nj.us.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>

		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.gov/agriculture </p>', 
1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
9,		'CHANGE_STATUS_PENDING_TO_ACTIVE', 
		'Change status Pending to Active',
		 '<p>Easement Purchase Program - {{FarmName}}</p>',
		 '<p>Dear {{PrimaryContactName}},</p>
		 <p>The Morris CADB has reviewed the appraisals of your farm and agreed on an offer amount. An offer letter will be sent to you via regular mail.</p>
		 <p>I look forward to working with you and welcome any questions you may have.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.gov/agriculture </p>', 
1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
10,		'CHANGE_STATUS_FROM_CLOSING_TO_POST_CLOSING', 
		'Change status From Closing to Post Closing',
		'<p>Easement Purchase Program - {{FarmName}}</p>',

		'<p>Date: {{TodaysDate}}</p>
		 <p>Enclosed are copies of the following closing documents for the {{ProjectName}}:</p>
		 <p>Recorded Deed of Easement</P>
		 <p>Affidavit of Title</P>
		 <p>Title Closing Statement</P>
		 <p>Title Insurance Policy</P>

		 <p>If you have any questions, please contact me.</p>
		 <p>Re: Post Closing Documents: {{OwnerLast}}, {{OwnerFirst}} </p>
		 <p>SADC # {{SADCNumber}} </p>
		 <p>{{Block}}, {{Lot}} </p>
		 <p>{{Municipality}} </p>
		 <p>County PIG Easement Purchase </p>

		 <p> Date: {{TodaysDate}}</p>

		 <p>Enclosed are copies of the following closing documents for the Williams Farm:</p>

		 <p>Recorded Deed of Easement</P>
		 <p>Affidavit of Title</P>
		 <p>Title Closing Statement</P>
		 <p>Title Insurance Policy</P>

		 <p>If you have any questions, please contact me. </p>
		 <p>{{ProgramAdmin}} </p>
	
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.gov/agriculture </p>', 
1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
11,		'CHANGE_STATUS_FROM_IN_POST_CLOSING_TO_PRESERVED', 
		'Change status From Post_Closing to Preserved', 
		'<p>Easement Purchase Program - {{FarmName}}</p>',
		'<p>Re: Morris County Agriculture Development Board</p>

		 <p>NOTICE OF PURCHASE OF DEVELOPMENT EASEMENT</p>

		 <p>Please take notice that the following property has been permanently preserved with funding from the Morris County Open Space, 
		   Recreation, Farmland and Historic Preservation Trust through the Morris County Agriculture Development Board:</p>
		
		<p>Landowner: {{OwnerFirst}} {{OwnerLast}} </p>
		<p> Municipality: {{Municipality}}</p>
		<p>Block/Lot: {{Block}}/{{Lot}} </p>
		<p>Acres Preserved: {{Acres}} </p>

		<p> The Deed has been filed at the Morris County Hall of Records in Deed Book {{DeedBook}} at Page {{DeedPage}}. A copy is enclosed. If you have any questions regarding this matter please contact me at (973) 829 8120 or at kcoyle@co.morris.nj.us. </p>

		<p>Per N.J.A.C. 2:76-6.13(d)2, the Notice of Development Easement Purchase is also being forwarded to: </p>
		<p>Morris County Planning Board </p>
		<p>Municipal Governing Body </p>
		<p>Municipal Tax Assessor </p>
		<p>Municipal Planning Board </p>
		<p>Morris County Soil Conservation District </p>', 
1);
GO

