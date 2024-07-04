namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Clase habitación
    /// </summary>
    public class Room : Structure
    {

        /// <summary>
        /// Numero de habitacion
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        ///Si es de producción = <see langword="true"/>,
        ///si es de oficina = <see langword="false"/>.
        /// </summary>
        public bool IsProduction { get; set; }
        /// <summary>
        /// Breve descripcion sobre la habitacion
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Piso al que pertenece la habitacion
        /// </summary>
        public Floor Floor { get; set; }
        /// <summary>
        /// Identificador del Piso
        /// </summary>
        public Guid FloorId { get; set; }


        /// <summary>
        /// Constructor por defecto de Room
        /// </summary>
        protected Room() { }

        /// <summary>
        /// Constructor de la clase Room
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isProduction"></param>
        /// <param name="description"></param>
        /// <param name="floor"></param>
        public Room(Guid id, int number, bool isProduction, string description, Floor floor)
            : base(id)
        {
            Number = number;
            IsProduction = isProduction;
            Description = description;
            Floor = floor;
            FloorId = floor.Id;
        }

    }
}