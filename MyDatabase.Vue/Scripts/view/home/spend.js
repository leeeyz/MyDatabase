const spend = {
    template: "#spend",
    data: function () {
        return {
            dateFromTo: [getDate(true), getDate()],
            spendTypeSelectItems: [],
            spendTypes: [],
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
                SpendFee: [
                    { required: true, message: "请填写花费", trigger: "blur" },
                    { type: "number", required: true, message: "花费必须为数值" }
                ],
                SpendDate: [
                    { type: "date", required: true, message: "请选择花费时间", trigger: "change" }
                ],
                SpendType: [
                    { required: true, message: '请选择花费类型', trigger: "change" }
                ],
            },
            isAdd: true,
            saveLoading: false,
        }
    },
    created: function () {
        this.setCbb();
        this.query();
    },
    methods: {
        setCbb: function () {
            var _this = this;
            axios.get(serverUrl + "api/Spend/SpendTypeSelectItems")
                .then(function (response) {
                    if (response.data.IsSuccess) {
                        _this.spendTypeSelectItems = response.data.SelectItems;
                    }
                    else {
                        _this.$message.error(response.data.Msg);
                    }
                })
                .catch(function (error) {
                    _this.$message.error(error.message);
                });
        },
        query: function () {
            var _this = this;
            _this.queryLoading = true;
            axios.get(serverUrl + "api/Spend/SpendIndex", {
                params: {
                    "pageIndex": this.pageIndex - 1,
                    "pageSize": this.pageSize,
                    "spendDateFrom": this.dateFromTo != null ? this.dateFromTo[0] : "",
                    "spendDateTo": this.dateFromTo != null ? this.dateFromTo[1] : "",
                    "spendTypes": this.spendTypes.join(","),
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
                SpendFee: 0,
                SpendDate: new Date(getDate()),
                SpendType: this.spendTypeSelectItems.length > 0 ? this.spendTypeSelectItems[0].Key : "",
                Remark: "",
            };
            this.isAdd = true;
        },
        edit: function (row) {
            var _this = this;
            var vmodel = JSON.parse(JSON.stringify(row));
            axios.post(serverUrl + "api/Spend/SpendDetail", vmodel)
                .then(function (response) {
                    if (response.data.IsSuccess) {
                        _this.formTitle = "修改";
                        _this.formOpen = true;
                        _this.model = response.data.VModel;
                        _this.model.SpendDate = new Date(_this.model.SpendDate)
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
                    axios.post(serverUrl + "api/Spend/SpendDelete", vmodel)
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
                        axios.post(serverUrl + "api/Spend/SpendCreate", vmodel)
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
                        axios.post(serverUrl + "api/Spend/SpendEdit", vmodel)
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
