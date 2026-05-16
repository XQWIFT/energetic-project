namespace EnergeticProjectX.Enums
{
    /// <summary>
    /// Тип контрагента пользователя.
    /// </summary>
    public enum Contractors
    {
        [System.ComponentModel.Description("Физ. лицо")]
        PhysicalPerson,

        [System.ComponentModel.Description("Юр. лицо")]
        LegalEntity,

        [System.ComponentModel.Description("ИП")]
        IndividualEntrepreneur
    }
}
