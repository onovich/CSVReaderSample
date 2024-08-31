using System.IO;
using System.Threading.Tasks;
using NReco.Csv;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class TemplateCore {

    public static async Task LoadSO(TemplateContext ctx) {

        {
            var handle = Addressables.LoadAssetsAsync<RoleSO>("SO_Role", null);
            var roleList = await handle.Task;
            foreach (var so in roleList) {
                ctx.RoleTM_Add(so.tm);
            }
            ctx.roleHandle = handle;
        }

        {
            var handle = Addressables.LoadAssetAsync<TextAsset>("CSV_Role");
            TextAsset csv = await handle.Task;
            Stream stream = new MemoryStream(csv.bytes);
            StreamReader sr = new StreamReader(stream);
            CsvReader reader = new CsvReader(sr);

            reader.Read();
            while (reader.Read()) {
                RoleTM role = new RoleTM();
                role.FromCSV(reader);
                ctx.RoleTM_Add(role);
            }

            ctx.roleHandle = handle;
            ctx.roleStream = stream;
            ctx.roleSR = sr;

            if (handle.IsValid()) {
                Addressables.Release(handle);
            }
            sr.Dispose();
            stream.Dispose();
        }

    }

    public static void Release(TemplateContext ctx) {
        if (ctx.roleHandle.IsValid()) {
            Addressables.Release(ctx.roleHandle);
            ctx.roleSR?.Dispose();
            ctx.roleStream?.Dispose();
        }
    }

}