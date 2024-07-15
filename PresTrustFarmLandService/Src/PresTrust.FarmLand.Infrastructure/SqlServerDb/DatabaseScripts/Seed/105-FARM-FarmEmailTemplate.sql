INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
	 1, 
 'CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE', 
 'Change status from Agreement Approved to Active', 
 'Morris County Farm Mitigation Program – Agreement Approved to Active', 

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
Sincerely,</p>
<p>{{ProgramAdmin}}<br>
Morris County Agriculture Development Board<br>
Morris County Office of Planning & Preservation<br>
P.O. Box 900<br>
Morristown, NJ 07963-0900<br>
(973) 326-9025 (O)<br>
E-Mail: kcoyle@co.morris.nj.us<br>
Website: https://www.morriscountynj.gov/agriculture </p>', 
    1);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   2, 'TRIGER_THE_EMAIL_WHEN__SADC_BUTTON_IS_ENABLED',
		'Triger The Email When SADC Button is Eanbled',
		'Morris County Farm Lands Program – SADC Button is Eanbled', 

		'<P>Dear {{SADCContact}},</P>
		<P>Pursuant to N.J.A.C. 2:76-3.6, the Morris County Agriculture Development Board (Morris CADB) 
		hereby submits a request for Certification of a Farmland Preservation Program (Term-Year Program) 
		for the above referenced property.</P>
		<P>The following are enclosed for your review:</p>
		<p>Petition;</p>
		<p>Signed original copy of the Agreement;</p>
		<p>Morris CADB resolution;</p>
		<p>Copy of owner of last record search.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		Sincerely,</p>
		<p>{{ProgramAdmin}}<br>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		(973) 326-9025 (O)<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.gov/agriculture </p>', 

2);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   3,	'CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED', 
		'Change status from Requested to Approved', 
		'Morris County Farm Mitigation Program – Requested to Approved', 

		'<P>Dear {{PrimaryContactName}},</P>
		<P>I am pleased to forward to you the Term Farmland Preservation Program Agreement for your property.</p> 
		<p>Please sign the document before a witness (notary public) and have the witness attest the signature. Once signed, please return the document to me</p>
		<p>I will then present the document for signature to the Morris County Agriculture Development Board (CADB) and to the State Agriculture Development Committee (SADC) for certification. Lastly, the County will record the document in the Hall of Records.</p>
		<P>The following are enclosed for your review:</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		Sincerely,</p>
		<p>{{ProgramAdmin}}<br>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		(973) 326-9025 (O)<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.gov/agriculture </p>', 

3);
GO

INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   4,	'CHANGE_STATUS_FROM_DRAFT_TO_REQUESTED', 
		'Change status from Draft to Requested', 
		'Morris County Farm Mitigation Program – Draft to Requested', 

		'<P>Dear {{PrimaryContactName}},</P>
		<P>I am in receipt of your Petition document and have added this item to the Morris CADB’s {{NextMeetingDate}} meeting agenda. The board will discuss the matter and if found acceptable, will direct staff to prepare a resolution approving the Petition.</p> 
		<p>By copy of this letter, per N.J.A.C. 2:76-3.5, I am requesting that the Morris County Counsel’s Office order an “owner of last record” title search, verifying your ownership of the land.</p>
		<p>Approval of the Petition by the CADB and creation of the farmland preservation program will be signified by an agreement between you and the CADB to retain the land in agricultural production for a minimum period of eight years.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		Sincerely,</p>
		<p>{{ProgramAdmin}}<br>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		(973) 326-9025 (O)<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.gov/agriculture </p>', 

4);
GO