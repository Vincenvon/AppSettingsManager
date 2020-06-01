import { connect } from 'react-redux'
import React, { useEffect } from 'react';
import * as S from './styled';
import { settingsReadStart, settingsUpdateStart, settingsValueChanged } from 'root/redux/actionCreators/settings';
import { Loader, ReloadButton, SubmitButton } from 'root/components';

const Settings = ({ isLoading, data, settingsReadStart, settingsUpdateStart, settingsValueChanged }) => {
    useEffect(() => {
        settingsReadStart();
    }, []);

    const handleJsonChanged = e => {
        settingsValueChanged({ value: e.target.value });
    };

    const handleSubmitClick = () => {
        settingsUpdateStart({ data });
    };

    return (
        <S.Page>
            {isLoading && <Loader />}
            <S.TextAreaContainer>
                <S.TextArea value={data && data.json} placeholder="Nothing to show here" onChange={handleJsonChanged} />
            </S.TextAreaContainer>
            <S.ButtonsContainer>
                <ReloadButton onClick={settingsReadStart} />
                <SubmitButton onClick={handleSubmitClick} />
            </S.ButtonsContainer>
        </S.Page>
    )
};

const mapStateToProps = state => ({
    isLoading: state.settings.isLoading,
    data: state.settings.data,
});

const mapDispatchToProps = ({
    settingsReadStart,
    settingsUpdateStart,
    settingsValueChanged,
});

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Settings);
