import React, { useEffect } from 'react';
import MaterialTable from "material-table";
import * as S from './styled';
import { forwardRef } from 'react';
import { columns } from './columnDefinition';
import { connect } from 'react-redux';
import { historyReadStart } from 'root/redux/actionCreators/history';

import AddBox from '@material-ui/icons/AddBox';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';

const tableIcons = {
    Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
    Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
    Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
    DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
    Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
    Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
    ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
    ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
};

const options = {
    draggable: false,
    filtering: false,
    grouping: false,
    pageSize: 10,
    showTitle: false,
    search: false,
    selection: false,
    sorting: true,
};

const History = ({ data, historyReadStart }) => {
    useEffect(() => {
        historyReadStart();
    }, []);

    const handlePageChanged = pageNumber => {
        debugger;
    };

    const handleOrderChanged = (number, direction) => {
        debugger;
    };

    const handleRowsPerPageChanged = pageSize => {

    };

    return (
        <S.Container>
            <MaterialTable
                columns={columns}
                data={data.data}
                totalCount={data.total}
                icons={tableIcons}
                onChangePage={handlePageChanged}
                onOrderChange={handleOrderChanged}
                onChangeRowsPerPage={handleRowsPerPageChanged}
                options={options}
            />
        </S.Container>
    );
}

const mapStateToProps = state => ({
    isLoading: state.history.isLoading,
    data: state.history.data,
});

const mapDispatchToProps = ({
    historyReadStart,
});

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(History);
