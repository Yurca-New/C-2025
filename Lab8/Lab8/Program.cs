using Lab8;

string PacientFile= "../../../patients.txt";
string DiagnosFile = "../../../diagnoses.txt";
List<Diagnos> diagnoses = FileInteraction.ReadDiagnos(DiagnosFile);
List<Pacient> pacients = FileInteraction.ReadPacient(PacientFile, diagnoses);
ConsoleInteraction.DisplayPacients(pacients, diagnoses);
diagnoses[0].NameHospitalDipartment = "New Hospital Department";
diagnoses[0].DurationOfTreatment = 14;
ConsoleInteraction.DisplayPacients(pacients, diagnoses);
