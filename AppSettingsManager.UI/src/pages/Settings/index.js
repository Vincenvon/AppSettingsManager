import JSONEditor from 'jsoneditor';
import 'jsoneditor/dist/jsoneditor.css';
import React, { useEffect, useMemo, useRef } from 'react';
import { connect } from 'react-redux';
import { Loader, ReloadButton, SubmitButton } from 'root/components';
import { settingsReadStart, settingsUpdateStart } from 'root/redux/actionCreators/settings';
import * as S from './styled';

const Settings = ({ isLoading, data, settingsReadStart, settingsUpdateStart }) => {
    const jsonEditorContainerRef = useRef(null);

    const jsonEditor = useMemo(() => {
        return jsonEditorContainerRef.current ? new JSONEditor(jsonEditorContainerRef.current, { mode: 'tree', }) :
            null;
    }, [jsonEditorContainerRef.current]);

    useEffect(() => {
        settingsReadStart();
        return () => jsonEditor && jsonEditor.destroy();
    }, []);

    useEffect(() => {
        jsonEditor && jsonEditor.set(data.json ? JSON.parse(data.json) : {});
    }, [data, jsonEditor]);

    const handleSubmitClick = () => {
        const json = jsonEditor.get();
        settingsUpdateStart({ data: { json: JSON.stringify(json, null, 2) } });
    };

    return (
        <S.Page>
            {isLoading && <Loader />}
            <S.TextAreaContainer>
                <S.JsonEditorContainer ref={jsonEditorContainerRef} />
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
});

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Settings);
