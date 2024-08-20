namespace PresTrust.FarmLand.Domain.Entities;

public class FarmTermAppAdminDetailsEntity
{
public int 		    Id							{get; set;}
public int		    ApplicationId				{get; set;}
public int?		    SADCId						{get; set;}
public decimal?		MaxGrant					{get; set;}
public bool			PermanentlyPreserved		{get; set;}
public bool			MunicipallyApproved		    {get; set;}
public DateTime?	EnrollmentDate				{get; set;}
public DateTime?	RenewalDate				    {get; set;}
public DateTime?	ExpirationDate				{get; set;}
public DateTime?	RenewalExpirationDate		{get; set;}
public string       Comment                     {get; set;} 
public string       LastUpdatedBy				{get; set;}
public DateTime?    LastUpdatedOn               {get; set;}

}
