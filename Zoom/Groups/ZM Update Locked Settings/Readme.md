<br>#     Zoom</br>
<br>Update Locked Settings</br>
<br>Update a [group's](https://support.zoom.us/hc/en-us/articles/204519819-Group-Management-) locked settings. If you lock a setting, the group members will not be able to modify it individually. Note: The `force_pmi_jbh_password` field under meeting settings is planned to be deprecated on September 22, 2019. This field will be replaced by another field that will provide the same functionality.

**Prerequisite**: Pro, Business, or Education account
**Scopes**: `group:write:admin`
 </br>
<br>Method: Patch</br>
<br>OperationID: groupLockedSettings</br>
<br>EndPoint:</br>
<br>/groups/{groupId}/lock_settings</br>
