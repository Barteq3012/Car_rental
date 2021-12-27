INSERT INTO RegistrationProof (FirstRegistrationDate, Plate) VALUES (CONVERT(datetime2, '30/12/2000 12:00', 103), 'WBR3012')

INSERT INTO Car (Brand, Model, ProductionDate, Country, Mileage, RegistrationProofId)
VALUES ('Ferrari', 'Enzo', CONVERT(datetime2, '25/05/2016 09:00', 103), 'Italy', 6000, 1 ), ('Alfa Romeo', 'Brera', CONVERT(datetime2, '25/05/2016 09:00', 103), 'Italy', 186000, 1);