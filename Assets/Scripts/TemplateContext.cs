using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TemplateContext {

    Dictionary<int, RoleTM> roleTMDict;
    public AsyncOperationHandle roleHandle;
    public Stream roleStream;
    public StreamReader roleSR;

    public TemplateContext() {
        roleTMDict = new Dictionary<int, RoleTM>();
    }

    // Role TM
    public void RoleTM_Add(RoleTM role) {
        roleTMDict.Add(role.typeID, role);
        Debug.Log($"Role {role.typeID} added, Name = {role.name}, HP = {role.hp}");
    }

    public bool Role_TryGet(int typeID, out RoleTM role) {
        var has = roleTMDict.TryGetValue(typeID, out role);
        if (!has) {
            Debug.LogError($"Role {typeID} not found");
        }
        return has;
    }

    // Clear
    public void Clear() {
        roleTMDict.Clear();
    }

}