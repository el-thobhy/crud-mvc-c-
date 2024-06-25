using Aplikasi_Kota.Data_Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Aplikasi_Kota.Repositories
{
    public class RepositoryKecamatan
    {
        private readonly string _connectionString;
        public RepositoryKecamatan(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MasterKecamatan CreateData(MasterKecamatan model)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var query = @"INSERT INTO Master_Kecamatan(" +
                            "NamaKecamatan, KodeKecamatan, IdKota, IsDeleted, ModifiedBy, ModifiedDate) " +
                            "VALUES (" +
                            "@NamaKecamatan, @KodeKecamatan, @IdKota, @IsDeleted, @ModifiedBy, @ModifiedDate);" +
                            "SELECT CAST(SCOPE_IDENTITY() as int);";
                        var parameters = new
                        {
                            model.NamaKecamatan,
                            model.KodeKecamatan,
                            model.IdKota,
                            IsDeleted = false,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = 1
                        };
                        var rowAffected = dbConnection.Execute(query, parameters, transaction);
                        Console.WriteLine("Row Affected: " + rowAffected);
                        transaction.Commit();
                    }

                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
            return model;
        }

        public MasterKecamatan UpdateData(MasterKecamatan model)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var query = @"UPDATE Master_Kecamatan SET 
                              NamaKecamatan = @NamaKecamatan,
                              KodeKecamatan = @KodeKecamatan,
                              IdKota = @IdKota,
                              IsDeleted = @IsDeleted,
                              ModifiedDate = @ModifiedDate,
                              ModifiedBy = @ModifiedBy
                              WHERE Id = @Id;";
                        var parameters = new
                        {
                            model.NamaKecamatan,
                            model.KodeKecamatan,
                            model.IdKota,
                            IsDeleted = false,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = 1,
                            model.Id
                        };
                        var rowAffected = dbConnection.Execute(query, parameters, transaction);
                        Console.WriteLine("Row Affected: " + rowAffected);
                        transaction.Commit();
                    }

                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
            return model;
        }

        public MasterKecamatan SoftDeletedFlag(int id, bool isDeleted)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var query = @"UPDATE Master_Kecamatan 
                              SET IsDeleted = @IsDeleted,
                                  ModifiedDate = @ModifiedDate,
                                  ModifiedBy = @ModifiedBy
                              WHERE Id = @Id;";
                        var parameters = new
                        {
                            IsDeleted = isDeleted,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = 1,
                            Id = id
                        };
                        var rowsAffected = dbConnection.Execute(query, parameters, transaction);
                        transaction.Commit();

                        Console.WriteLine($"Rows Affected: {rowsAffected}");
                        return new MasterKecamatan { Id = id, IsDeleted = isDeleted };
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Error updating IsDeleted flag in MasterKecamatan", e);
                    }
                }
            }
        }

        public List<MasterKecamatan> GetKecamatanNative()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Master_Kecamatan as MKe " +
                    "JOIN Master_kota as MKo On MKe.IdKota=MKo.Id WHERE Mke.IsDeleted=0 ;";
                List<MasterKecamatan> result = connection.Query<MasterKecamatan, MasterKota, MasterKecamatan>(sql,
                    (kecamatan, kota) =>
                    {
                        kecamatan.Kota = kota;
                        return kecamatan;
                    }
                    ).ToList();
                return result;
            }
        }


        public MasterKecamatan GetKecamatanByIdNative(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Master_Kecamatan as MKe " +
                    $"JOIN Master_kota as MKo On MKe.IdKota=MKo.Id WHERE MKe.Id={id} AND Mke.IsDeleted=0 ;";
                MasterKecamatan result = connection.Query<MasterKecamatan, MasterKota, MasterKecamatan>(sql,
                    (kecamatan, kota) =>
                    {
                        kecamatan.Kota = kota;
                        return kecamatan;
                    }
                    ).FirstOrDefault();
                return result;
            }
        }
    }
}
