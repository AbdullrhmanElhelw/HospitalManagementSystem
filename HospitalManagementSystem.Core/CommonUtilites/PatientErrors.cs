namespace HospitalManagementSystem.Core.CommonUtilites;

public static class PatientErrors
{
    public static Error NotFound(int id)=> new($"Patient with id {id} not found");
    public static Error NotFound(string name) => new($"Patient with name {name} not found");
}
