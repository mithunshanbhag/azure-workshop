# Labs: Azure Monitor

## #1: KQL Query

Extract the top 20 most time-consuming function app executions in the last 4 hours.

```bash
requests
| where timestamp > ago(30d)
| where cloud_RoleName =~ '<@replace-function-app-name>' and operation_Name =~ '<@replace-function-name>'
| order by timestamp desc
| take 20
```

-----

## #2: KQL Query (with nested properties)

Same query as above but using execution time reported in customDimension property.

```bash
requests
| where timestamp > ago(30d)
| where cloud_RoleName =~ '<@replace-function-app-name>' and operation_Name =~ '<@replace-function-name>'
| project actualTime=todouble(customDimensions.FunctionExecutionTimeMs), cloud_RoleName, cloud_RoleInstance
| order by actualTime desc
| take 20
```

-----

## #3: Metric-based Alerts

Create a metrics-based alert to email you when total blobs in a storage account exceed (say) 5.
