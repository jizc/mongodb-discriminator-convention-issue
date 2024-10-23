# MongoDB discriminator convention issue
- Run and see that output has `_t` instead of `__type`
- Switch `MongoDB.Driver` to `2.30.0` and see that output has `__type` as expected

### Cause
The issue seems to have been introduced by this commit: https://github.com/mongodb/mongo-csharp-driver/commit/f54ba02046b543375c7160ace0e512a6a7308763
