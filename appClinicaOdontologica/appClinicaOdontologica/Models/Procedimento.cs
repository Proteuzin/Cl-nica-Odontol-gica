using System;
using System.Collections.Generic;

namespace appClinicaOdontologica.Models;

public partial class Procedimento
{
    public int Id { get; set; }

    public string NomeProcedimento { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Valor { get; set; }

    public int PacienteId { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Paciente Paciente { get; set; } = null!;
}
