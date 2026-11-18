using System;
using System.Collections.Generic;

namespace appClinicaOdontologica.Models;

public partial class Agendamento
{
    public int Id { get; set; }

    public DateTime DataConsulta { get; set; }

    public string? Observacoes { get; set; }

    public int PacienteId { get; set; }

    public int ProcedimentoId { get; set; }

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual Procedimento Procedimento { get; set; } = null!;
}
