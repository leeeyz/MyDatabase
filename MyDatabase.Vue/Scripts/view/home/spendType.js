﻿const spendType = {
    template: "#spendType",
    data: function () {
        return {
            tableData: [],
            queryLoading: false,
            pageIndex: 1,
            pageSize: 10,
            total: 0,
            pageSizes: [10, 20, 50, 100],
            formTitle: "",
            formOpen: false,
            model: {},
            rules: {
                ID: [
                    { required: true, message: "请填写ID", trigger: "blur" }
                ],
                TypeName: [
                    { required: true, message: "请填写花费类型", trigger: "blur" }
                ]
            },
            isAdd: true,
            saveLoading: false,
        }
    },
    created: function () {
        this.query();
    },
    methods: {
        query: function () {
            var _this = this;
            _this.queryLoading = true;
            axios.get(serverUrl + "api/Spend/SpendTypeIndex", {
                params: {
                    "pageIndex": this.pageIndex - 1,
                    "pageSize": this.pageSize
                }
            })
                .then(function (response) {
                    _this.queryLoading = false;
                    if (response.data.IsSuccess) {
                        _this.total = response.data.Total;
                        _this.tableData = response.data.Rows;
                    }
                    else {
                        _this.$message.error(response.data.Msg);
                    }
                })
                .catch(function (error) {
                    _this.queryLoading = false;
                    _this.$message.error(error.message);
                });
        },
        sizeChange: function (pageSize) {
            this.pageSize = pageSize;
            this.query();
        },
        pageIndexChange: function (pageIndex) {
            this.pageIndex = pageIndex;
            this.query();
        },
        add: function () {
            this.formTitle = "增加";
            this.formOpen = true;
            this.model = {
                ID: "*",
                TypeName: "",
            };
            this.isAdd = true;
        },
        edit: function (row) {
            var _this = this;
            var vmodel = JSON.parse(JSON.stringify(row));
            axios.post(serverUrl + "api/Spend/SpendTypeDetail", vmodel)
                .then(function (response) {
                    if (response.data.IsSuccess) {
                        _this.formTitle = "修改";
                        _this.formOpen = true;
                        _this.model = response.data.VModel;
                        _this.isAdd = false;
                    }
                    else {
                        _this.$message.error(response.data.Msg);
                    }
                })
                .catch(function (error) {
                    _this.$message.error(error.message);
                });
        },
        del: function (row) {
            var _this = this;
            var vmodel = JSON.parse(JSON.stringify(row));
            this.$confirm("是否删除？", "提示", {
                type: 'warning'
            })
                .then(function () {
                    axios.post(serverUrl + "api/Spend/SpendTypeDelete", vmodel)
                        .then(function (response) {
                            if (response.data.IsSuccess) {
                                _this.$message({
                                    message: "删除成功！",
                                    type: "success"
                                });
                                _this.query();
                            }
                            else {
                                _this.$message.error(response.data.Msg);
                            }
                        })
                        .catch(function (error) {
                            _this.$message.error(error.message);
                        });
                });
        },
        save: function () {
            var _this = this;
            var vmodel = JSON.parse(JSON.stringify(_this.model));
            this.$refs.form.validate(function (valid) {
                if (valid) {
                    _this.saveLoading = true;
                    if (_this.isAdd) {
                        axios.post(serverUrl + "api/Spend/SpendTypeCreate", vmodel)
                            .then(function (response) {
                                _this.saveLoading = false;
                                if (response.data.IsSuccess) {
                                    _this.$message({
                                        message: "增加成功！",
                                        type: "success"
                                    });
                                    _this.$refs.form.resetFields();
                                    _this.query();
                                }
                                else {
                                    _this.$message.error(response.data.Msg);
                                }
                            })
                            .catch(function (error) {
                                _this.saveLoading = false;
                                _this.$message.error(error.message);
                            });
                    }
                    else {
                        axios.post(serverUrl + "api/Spend/SpendTypeEdit", vmodel)
                            .then(function (response) {
                                _this.saveLoading = false;
                                if (response.data.IsSuccess) {
                                    _this.$message({
                                        message: "修改成功！",
                                        type: "success"
                                    });
                                    _this.query();
                                }
                                else {
                                    _this.$message.error(response.data.Msg);
                                }
                            })
                            .catch(function (error) {
                                _this.saveLoading = false;
                                _this.$message.error(error.message);
                            });
                    }
                } else {
                    return false;
                }
            });
        },
        cancel: function () {
            this.formOpen = false;
        },
        formClose: function () {
            this.$refs.form.resetFields();
        },
    },
};
