# BLOB STORAGE

## #1: Data-triggered function app

Create & deploy a function app that processes blobs uploaded to a storage account's container.

[[SOLUTION]](../code-samples/function-app-blob-trigger/BlobTriggerFunction.cs)

-----

## #2: Data-triggered function app (binding expressions)

[[SOLUTION]](../code-samples/function-app-blob-trigger/BlobTriggerBindingExpressionFunction.cs)

-----

## #3: [HomeWork] Input binding

Create & deploy a function app that reads from an existing blob (in a storage account's container) every minute.

-----

## #4: Output binding

Create & deploy a function app that create a new blob (in a storage account's container) every minute.

[[SOLUTION]](../code-samples/function-app-blob-output/BlobOutputFunction.cs)

-----

## #5: Output binding (multiple outputs)

Multiple output blobs created from the same function app.

[[SOLUTION]](../code-samples/function-app-blob-images/ImageFunctions.cs)

-----

## #6: Output binding (binding expressions)

Similar to above examples, but output blob names must be timestamped or stamped with random guids.

[[SOLUTION]](../code-samples/function-app-blob-output/BlobOutputBindingExpressionFunction.cs)

-----

## #7: Output binding (runtime binder)

Create & deploy a function app that create a new blob (in a storage account's container) every minute. Output blob names should be in the format: `yyyy-MM-dd-HH-mm-ss.txt`

[[SOLUTION]](../code-samples/function-app-blob-output/BlobOutputRuntimeBinderFunction.cs)

-----
