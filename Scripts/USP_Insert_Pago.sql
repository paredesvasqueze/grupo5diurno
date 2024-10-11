create PROCEDURE USP_Insert_Pago
    @nIdUsuario INT,
    @nIdSuscripcion INT,
    @nMonto INT,
    @dFechaPago DATETIME,
    @cMetodoPago NVARCHAR(50) = NULL
AS
BEGIN
    INSERT INTO Pago (nIdUsuario, nIdSuscripcion, nMonto, dFechaPago, cMetodoPago)
    VALUES (@nIdUsuario, @nIdSuscripcion, @nMonto, @dFechaPago, @cMetodoPago);
END;
