import React from 'react';
import MaterialTable from "material-table";
import * as S from './styled';
import { icons } from './icons';

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

const Grid = ({ data, columns, gridState, total, onChangePage, onOrderChange, onChangeRowsPerPage }) => {
    return (
        <>
            <S.GridGlobalStyle />
            <MaterialTable
                columns={columns}
                data={data}
                totalCount={total}
                page={gridState.page}
                icons={icons}
                onChangePage={onChangePage}
                onOrderChange={onOrderChange}
                onChangeRowsPerPage={onChangeRowsPerPage}
                options={({
                    ...options,
                    pageSize: gridState.pageSize,
                })}
            />
        </>
    );
};

export default Grid;
