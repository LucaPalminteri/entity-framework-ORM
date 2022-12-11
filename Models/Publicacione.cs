using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Publicacione
{
    public int PublicacionId { get; set; }

    public int? ProductoId { get; set; }

    public int? TpublicacionWebProductoId { get; set; }

    public long? TcodigoDePublicacionWeb { get; set; }

    public string Nombre { get; set; } = null!;

    public int TemplateDetalleCompletoId { get; set; }

    public int? StockMinimo { get; set; }

    public bool Activo { get; set; }

    public DateTime VigenciaDesde { get; set; }

    public DateTime? VigenciaHasta { get; set; }

    public int CodProducto { get; set; }

    public int ServicioId { get; set; }
}
