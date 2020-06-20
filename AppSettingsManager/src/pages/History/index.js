import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import Grid from 'root/components/Grid';
import { historyGridStateChanged, historyReadStart } from 'root/redux/actionCreators/history';
import { columns } from './columnDefinition';
import * as S from './styled';
import { Loader, ReloadButton, SubmitButton } from 'root/components';

const History = ({ isLoading ,data, gridState, historyReadStart, historyGridStateChanged }) => {
    useEffect(() => {
        historyReadStart({ gridState });
    }, []);

    const handlePageChanged = pageNumber => {
        historyGridStateChanged({
            gridState: {
                ...gridState,
                page: pageNumber,
            }
        });
    };

    const handleOrderChanged = (number, direction) => {
        historyGridStateChanged({
            gridState: {
                ...gridState,
                sort: {
                    name: number && columns[number].field,
                    direction,
                },
            }
        });
    };

    const handleRowsPerPageChanged = pageSize => {
        historyGridStateChanged({
            gridState: {
                ...gridState,
                pageSize,
            }
        });
    };

    return (
        <S.Container>
            <Grid
                columns={columns}
                data={data.data}
                total={data.total}
                gridState={gridState}
                onChangePage={handlePageChanged}
                onOrderChange={handleOrderChanged}
                onChangeRowsPerPage={handleRowsPerPageChanged} />
        </S.Container>
    );
}

const mapStateToProps = state => ({
    isLoading: state.history.isLoading,
    data: state.history.data,
    gridState: state.history.gridState,
});

const mapDispatchToProps = ({
    historyReadStart,
    historyGridStateChanged,
});

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(History);
