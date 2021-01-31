CREATE TABLE Specialty
(
    Id INT IDENTITY PRIMARY KEY,
    NameSpecialty NVARCHAR(120) NOT NULL, 
    NameGroup NVARCHAR(20) NOT NULL, 
    NameGroup_2 NVARCHAR(20) NULL 
);

INSERT INTO Specialty 
VALUES
(N'Информационные системы и технологии в проектировании и производстве', N'ИТП-21', ''),
(N'Информационные системы и технологии в игровой индустрии', N'ИТИ-21', N'ИТИ-22'),
(N'Информатика и технологии программирования', N'ИП-21', '')