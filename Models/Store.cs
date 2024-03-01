using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// User Model
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Ingrese un correo electr�nico v�lido.")]
    public string UserEmail { get; set; }

    [Required(ErrorMessage = "La contrase�a es obligatoria.")]
    [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y como m�ximo {1} caracteres.", MinimumLength = 6)]
    public string UserPasswordHash { get; set; }

    [Required(ErrorMessage = "El salt de la contrase�a es obligatorio.")]
    public string PasswordSalt { get; set; }
}

// Model Store
public class Store
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la tienda es obligatorio.")]
    public string Name { get; set; }

    public string LocationStore { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string Otros { get; set; }
    public DateTime StoreCreationDate { get; set; } = DateTime.Now;

}

// Model Brands
public class Brand
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la marca es obligatorio.")]
    public string Name { get; set; }
}

public class StoreUserRelation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El ID de la tienda es obligatorio.")]
    public int StoreId { get; set; }

    [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
