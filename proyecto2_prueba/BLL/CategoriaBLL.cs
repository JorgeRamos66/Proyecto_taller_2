using System;
using System.Data;
using DAL;
using ML;

namespace BLL
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAL categoriaDAL = new CategoriaDAL();

        public DataTable ObtenerCategorias()
        {
            return categoriaDAL.ObtenerCategorias();
        }

        public void GuardarCategoria(Categoria categoria)
        {
            try
            {
                // Validaciones de negocio
                if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
                    throw new ArgumentException("El nombre de la categoría es obligatorio");

                if (string.IsNullOrWhiteSpace(categoria.DescripcionCategoria))
                    throw new ArgumentException("La descripción de la categoría es obligatoria");

                if (categoria.IdCategoria == 0)
                {
                    categoriaDAL.InsertarCategoria(categoria);
                }
                else
                {
                    categoriaDAL.ActualizarCategoria(categoria);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarEstadoCategoria(int idCategoria)
        {
            try
            {
                categoriaDAL.ModificarEstadoCategoria(idCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}