CREATE TABLE Examiner
(
    Id INT IDENTITY PRIMARY KEY,
    SurName NVARCHAR(30) NOT NULL, 
    EName NVARCHAR(30) NOT NULL, 
    Patronymic NVARCHAR(30) NOT NULL, 
    Exam NVARCHAR(100) NOT NULL,
    Exam_2 NVARCHAR(100) NOT NULL
);

INSERT INTO Examiner
VALUES
(N'Курочка', N'Константин', N'Сергеевич', N'ООП', N'КС'),
(N'Великович', N'Лев', N'Липович', N'Матем', N'Теория вероятностей'),
(N'Астраханцев', N'Сергей', N'Евгеньевич', N'Экономика', N'Маркетинг'),
(N'Пузенко', N'Иван', N'Николаевич', N'Ин-Яз', N'Бел-яз')