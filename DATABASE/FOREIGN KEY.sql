﻿USE MASTER
GO

USE ExamManagementDB
GO


--KHÓA NGOẠI
--
ALTER TABLE ADMINISTRATORS
ADD CONSTRAINT FK_ADMINISTRATORS_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

--
ALTER TABLE STUDENTS
ADD CONSTRAINT FK_STUDENTS_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

ALTER TABLE STUDENTS
ADD CONSTRAINT FK_STUDENTS_CLASSES_CLASSID FOREIGN KEY (CLASSID) REFERENCES CLASSES(CLASSID);

--
ALTER TABLE TEACHERS
ADD CONSTRAINT FK_TEACHERS_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

ALTER TABLE TEACHERS
ADD CONSTRAINT FK_TEACHERS_CLASSES_CLASSID FOREIGN KEY (CLASSID) REFERENCES CLASSES(CLASSID);

--
ALTER TABLE CLASSES
ADD CONSTRAINT FK_CLASSES_GRADE_GRADEID FOREIGN KEY (GRADEID) REFERENCES GRADE(GRADEID);

--*
ALTER TABLE TRAINING
ADD CONSTRAINT FK_TRAINING_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

--*
ALTER TABLE TRAININGHISTORY
ADD CONSTRAINT FK_TRAININGHISTORY_TRAINING_TRAININGID FOREIGN KEY (TRAININGID) REFERENCES TRAINING(TRAININGID);


ALTER TABLE TRAININGHISTORY
ADD CONSTRAINT FK_TRAININGHISTORY_TOPIC_TOPICID FOREIGN KEY (TOPICID) REFERENCES TOPIC(TOPICID);

--*
ALTER TABLE TESTS
ADD CONSTRAINT FK_TESTS_EXAM_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

ALTER TABLE TESTS
ADD CONSTRAINT FK_TESTS_TOPIC_TOPICID FOREIGN KEY (TOPICID) REFERENCES TOPIC(TOPICID);

--*
ALTER TABLE PROCESSES
ADD CONSTRAINT FK_PROCESSES_TESTS_TESTSID FOREIGN KEY (TESTID) REFERENCES TESTS(TESTID);

ALTER TABLE PROCESSES
ADD CONSTRAINT FK_PROCESSES_QUESTION_QUESTIONID FOREIGN KEY (QUESTIONID) REFERENCES QUESTION(QUESTIONID);


--*
ALTER TABLE STATISTIC
ADD CONSTRAINT FK_STATISTIC_TESTS_TESTID FOREIGN KEY (TESTID) REFERENCES TESTS(TESTID);

ALTER TABLE STATISTIC
ADD CONSTRAINT FK_STATISTIC_QUESTION_QUESTIONID FOREIGN KEY (QUESTIONID) REFERENCES QUESTION(QUESTIONID);

--*
ALTER TABLE RESULTOFTEST
ADD CONSTRAINT FK_RESULTOFTEST_TESTS_TESTID FOREIGN KEY (TESTID) REFERENCES TESTS(TESTID);


--*

ALTER TABLE TOPIC
ADD CONSTRAINT FK_TOPIC_SUBJECTS_SUBJECTID FOREIGN KEY (SUBJECTID) REFERENCES SUBJECTS(SUBJECTID);

ALTER TABLE TOPIC
ADD CONSTRAINT FK_TOPIC_GRADE_GRADEID FOREIGN KEY (GRADEID) REFERENCES GRADE(GRADEID);


ALTER TABLE EXAM
ADD CONSTRAINT FK_EXAM_SEMESTER_SEMESTERID FOREIGN KEY (SEMESTER) REFERENCES SEMESTER(SEMESTERID);

--*
ALTER TABLE TOPIC_DETAILS
ADD CONSTRAINT FK_TOPIC_DETAILS_TOPIC_TOPICID FOREIGN KEY (TOPICID) REFERENCES TOPIC(TOPICID);

--*
ALTER TABLE EXAM_DETAILS
ADD CONSTRAINT FK_EXAM_DETAILS_EXAM_EXAMID FOREIGN KEY (EXAMID) REFERENCES EXAM(EXAMID);

ALTER TABLE EXAM_DETAILS
ADD CONSTRAINT FK_EXAM_DETAILS_TOPIC_TOPICID FOREIGN KEY (TOPICID) REFERENCES TOPIC(TOPICID);

ALTER TABLE EXAM_DETAILS
ADD CONSTRAINT FK_EXAM_DETAILS_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

--*
ALTER TABLE SCHEDULE
ADD CONSTRAINT FK_SCHEDULE_TOPIC_SUBJECTID FOREIGN KEY (SUBJECTID) REFERENCES SUBJECTS(SUBJECTID);

ALTER TABLE SCHEDULE
ADD CONSTRAINT FK_SCHEDULE_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

ALTER TABLE SCHEDULE
ADD CONSTRAINT FK_SCHEDULE_EXAM_EXAMID FOREIGN KEY (EXAMID) REFERENCES EXAM(EXAMID);


--*
ALTER TABLE QUESTIONSSTORAGE
ADD CONSTRAINT FK_QUESTIONSSTORAGE_USERACCOUNTS_PERSONALID FOREIGN KEY (PERSONALID) REFERENCES USERACCOUNTS(PERSONALID);

ALTER TABLE QUESTIONSSTORAGE
ADD CONSTRAINT FK_QUESTIONSSTORAGE_QUESTION_QUESTIONID FOREIGN KEY (QUESTIONID) REFERENCES QUESTION(QUESTIONID);

--*
ALTER TABLE PERCENTAGEOFQUESTION
ADD CONSTRAINT FK_PERCENTAGEOFQUESTION_QUESTION_QUESTIONID FOREIGN KEY (QUESTIONID) REFERENCES QUESTION(QUESTIONID);

ALTER TABLE PERCENTAGEOFQUESTION
ADD CONSTRAINT FK_PERCENTAGEOFQUESTION_EXAM_EXAMID FOREIGN KEY (EXAMID) REFERENCES EXAM(EXAMID);

--*
ALTER TABLE USERACCOUNTS
ADD CONSTRAINT FK_USERACCOUNTS_PERMISSION_PERMISSIONID FOREIGN KEY (USERLEVEL) REFERENCES PERMISSION(PERMISSIONID)