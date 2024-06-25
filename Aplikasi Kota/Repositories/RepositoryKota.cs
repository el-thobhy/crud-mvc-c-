using Aplikasi_Kota.Data_Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Aplikasi_Kota.Repositories
{
    public class RepositoryKota
    {
        private readonly string _connectionString;
        public RepositoryKota(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MasterKota CreateData(MasterKota model)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var query = @"INSERT INTO Master_Kota(" +
                            "NamaKota, KodeKota , IsDeleted, ModifiedBy, ModifiedDate) " +
                            "VALUES (" +
                            "@NamaKota, @KodeKota, @IsDeleted, @ModifiedBy, @ModifiedDate);" +
                            "SELECT CAST(SCOPE_IDENTITY() as int);";
                        var parameters = new
                        {
                            model.NamaKota,
                            model.KodeKota,
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

        public MasterKota UpdateData(MasterKota model)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var query = @"UPDATE Master_Kota SET 
                              NamaKota = @NamaKota,
                              KodeKota = @KodeKota,
                              IsDeleted = @IsDeleted,
                              ModifiedDate = @ModifiedDate,
                              ModifiedBy = @ModifiedBy
                              WHERE Id = @Id;";
                        var parameters = new
                        {
                            model.NamaKota,
                            model.KodeKota,
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

        public MasterKota SoftDeletedFlag(int id, bool isDeleted)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var query = @"UPDATE Master_Kota 
                              SET IsDeleted = @IsDeleted,
                                  ModifiedDate = @ModifiedDate,
                                  ModifiedBy = @ModifiedBy
                              WHERE Id = @Id";
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
                        return new MasterKota { Id = id, IsDeleted = isDeleted };
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Error updating IsDeleted flag in MasterKota", e);
                    }
                }
            }
        }

        public List<MasterKota> GetKotaNative()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Master_Kota as Mk WHERE Mk.IsDeleted=0";
                List<MasterKota> result = connection.Query<MasterKota>(sql).ToList();
                return result;
            }
        }
        public MasterKota GetKotaByIdNative(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Master_Kota as Mk WHERE Id={id} AND Mk.IsDeleted=0";
                MasterKota result = connection.Query<MasterKota>(sql).FirstOrDefault() ;
                return result;
            }
        }
    }
}
