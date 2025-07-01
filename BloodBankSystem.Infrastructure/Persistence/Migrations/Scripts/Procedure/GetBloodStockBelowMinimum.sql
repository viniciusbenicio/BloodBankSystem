CREATE OR ALTER PROCEDURE GetBloodStockBelowMinimum 
(
    @BloodType NVARCHAR(3),
    @MinQuantity INT 
)
AS
BEGIN
    
    SELECT 
	BS.Id,
	BS.BloodType,
	BS.HRFactor,
	BS.QuantityML
	FROM BloodStocks AS BS
	WHERE BS.BloodType = @BloodType and BS.QuantityML <= @MinQuantity
END
GO
