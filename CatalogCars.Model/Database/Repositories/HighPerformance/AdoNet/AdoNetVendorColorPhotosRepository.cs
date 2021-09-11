using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetVendorColorPhotosRepository : IVendorColorPhotosRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetVendorColorPhotosRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid vendorColorId, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM VendorColorPhotos " +
                $"WHERE VendorColorPhotos.VendorColorId = '{vendorColorId}' AND VendorColorPhotos.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetVendorColorPhotoId(Guid vendorColorId, string name)
        {
            var query = $"SELECT TOP(1) VendorColorPhotos.Id " +
                $"FROM VendorColorPhotos " +
                $"WHERE VendorColorPhotos.VendorColorId = '{vendorColorId}' AND VendorColorPhotos.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref VendorColorPhoto entity)
        {
            if (!Contains(entity.VendorColorId, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [VendorColorPhotos] (Id, VendorColorId, Name, [Full], Orig, Small, Image, ThumbS, ThumbM, " +
                    $"AutoMain, ThumbS2x, Cattouch, Wizardv3, IslandOff, Wizardv3mr, Resolution92x69, Resolution120x90, " +
                    $"Resolution320x240, Resolution456x342, Resolution832x624, Resolution1200x900, Resolution1200x900n) VALUES " +
                    $"('{entity.Id}', '{entity.VendorColorId}', @Name, @Full, @Orig, @Small, @Image, @ThumbS, @ThumbM, @AutoMain, " +
                    $"@ThumbS2x, @Cattouch, @Wizardv3, @IslandOff, @Wizardv3mr, @Resolution92x69, @Resolution120x90, " +
                    $"@Resolution320x240, @Resolution456x342, @Resolution832x624, @Resolution1200x900, @Resolution1200x900n)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@Full", SqlDbType = SqlDbType.NVarChar, Value = entity.Full.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Orig", SqlDbType = SqlDbType.NVarChar, Value = entity.Orig.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Small", SqlDbType = SqlDbType.NVarChar, Value = entity.Small.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Image", SqlDbType = SqlDbType.NVarChar, Value = entity.Image.GetDbValue() },
                    new SqlParameter() { ParameterName = "@ThumbS", SqlDbType = SqlDbType.NVarChar, Value = entity.ThumbS.GetDbValue() },
                    new SqlParameter() { ParameterName = "@ThumbM", SqlDbType = SqlDbType.NVarChar, Value = entity.ThumbM.GetDbValue() },
                    new SqlParameter() { ParameterName = "@AutoMain", SqlDbType = SqlDbType.NVarChar, Value = entity.AutoMain.GetDbValue() },
                    new SqlParameter() { ParameterName = "@ThumbS2x", SqlDbType = SqlDbType.NVarChar, Value = entity.ThumbS2x.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Cattouch", SqlDbType = SqlDbType.NVarChar, Value = entity.Cattouch.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Wizardv3", SqlDbType = SqlDbType.NVarChar, Value = entity.Wizardv3.GetDbValue() },
                    new SqlParameter() { ParameterName = "@IslandOff", SqlDbType = SqlDbType.NVarChar, Value = entity.IslandOff.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Wizardv3mr", SqlDbType = SqlDbType.NVarChar, Value = entity.Wizardv3mr.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution92x69", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution92x69.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution120x90", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution120x90.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution320x240", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution320x240.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution456x342", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution456x342.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution832x624", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution832x624.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution1200x900", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution1200x900.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Resolution1200x900n", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution1200x900n.GetDbValue() }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetVendorColorPhotoId(entity.VendorColorId, entity.Name);
            }

            return true;
        }
    }
}
